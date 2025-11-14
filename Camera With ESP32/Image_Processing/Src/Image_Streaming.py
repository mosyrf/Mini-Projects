import paho.mqtt.client as mqtt
from paho.mqtt.client import CallbackAPIVersion
import cv2
import numpy as np
import random
import ssl
import tempfile
import os

# ==========================================================
# --- Konfigurasi Keamanan MQTT ---
# True = Menggunakan SSL (Port 8884, butuh sertifikat)
# False = Menggunakan Non-SSL (Port 1883, standar)
# ==========================================================
USE_MQTT_SSL = True
# ==========================================================


# --- Konfigurasi MQTT (Disesuaikan dengan ESP32) ---
MQTT_SERVER = "broker.avisha.id"
MQTT_USER = "mosyrf"
MQTT_PASSWORD = "mosyrfMQTT"
MQTT_TOPIC = "mosyrf/camera"
CLIENT_ID = f"PythonSub-{random.randint(0, 10000)}"

# Port dinamis berdasarkan saklar
if USE_MQTT_SSL:
    MQTT_PORT = 8884
else:
    MQTT_PORT = 1883

# Nama jendela tampilan
WINDOW_NAME = "ESP32-CAM Stream"


# --- SERTIFIKAT CA (Hanya untuk SSL) ---
ROOT_CA_CERT = """
-----BEGIN CERTIFICATE-----
MIIDtTCCAp2gAwIBAgIUOKMAqMXFCssUwLZtEx+8/dj+d/AwDQYJKoZIhvcNAQEL
BQAwajELMAkGA1UEBhMCSUQxEDAOBgNVBAgMB0pha2FydGExEDAOBgNVBAcMB0ph
a2FydGExDTALBgNVBAoMBEVNUVgxDTALBgNVBAsMBE1RVFQxGTAXBgNVBAMMEGJy
b2tlci5hdmlzaGEuaWQwHhcNMjUxMTAyMTEzODM2WhcNMjYxMTAyMTEzODM2WjBq
MQswCQYDVQQGEwJJRDEQMA4GA1UECAwHSmFrYXJ0YTEQMA4GA1UEBwwHSmFrYXJ0
YTENMAsGA1UECgwERU1RWDENMAsGA1UECwwETVFUVDEZMBcGA1UEAwwQYnJva2Vy
LmF2aXNoYS5pZDCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAMAvKNx4
/EBrDB/vhjL6L+hnoRuM623QFqkmje+I7YjsL0ehNTBnTCTbI0giflQlx0lE1OUC
r3HbahOFovFJGbMbLF3JgKvJ7rtmfEhaURyuSNCAVJRxmnEFt+OgB6SntSQaJ0zP
q5DT2EapWdiwbFkYsDTO6kyRtkBReZVc4rhTCaHFJnxEab3DbzVzteC2g8GSv0NX
clO3+6yi9bRh0uH0u3rfux4I9r4GMYF9vdC7NDDaVFeHIsQRXKW1dh4KajdMnJvl
K25whh4HAEryZ5JJsyCviWcmjZhvPW/WEha1ORPjpcw3dbCSa40zSQVoFKgJAPvJ
mcsCKk6TUT8ENiUCAwEAAaNTMFEwHQYDVR0OBBYEFHDNv7W0hpVlgFt82uqmGU0O
AnPuMB8GA1UdIwQYMBaAFHDNv7W0hpVlgFt82uqmGU0OAnPuMA8GA1UdEwEB/wQF
MAMBAf8wDQYJKoZIhvcNAQELBQADggEBAIOK9N+TF7t/2bsbX3RlFzKG6Nn+qkA4
KNXEbfHhgKN/xRrZWw5ay8v+mhwTKh/bgv2qb8sEVN4+79cgio+azzGGVTOsYQ0R
bWblQy40xPZSzylEHPLtxDEvy/iQLeenV3MFIGRNgzDOzum5zEH6Vna81LaGyqOf
W2fzRa0QuyV8i+NzUIDwKd2S6UBMqAqCkmoL3c8cAFXMabVuN3Lz+co0yebDX2kW
SihneS6XYxxRAgoien4o814k4rP1OYarFUNSK7JFOOj7uyAr/3VkgX3e0n1M0IfD
vzvlEDsvCUU3FP8IN5bhgF+sth/w6K4qUsmsWzdds4HJoMjFBpCQwyA=
-----END CERTIFICATE-----
"""

# --- Fungsi Callback Koneksi ---
def on_connect(client, userdata, flags, reason_code, properties):
    """Dipanggil ketika klien menerima respons CONNECT dari broker."""
    if reason_code == 0:
        print(f"✅ Terhubung ke {MQTT_SERVER}:{MQTT_PORT}")
        client.subscribe(MQTT_TOPIC)
        print(f"📡 Berlangganan topik: {MQTT_TOPIC}")
    else:
        print(f"❌ Koneksi gagal. Code: {reason_code}")

# --- Fungsi Callback Pesan ---
def on_message(client, userdata, msg):
    """Dipanggil ketika pesan diterima."""
    try:
        image_bytes = msg.payload
        # Decode byte array ke gambar OpenCV
        np_array = np.frombuffer(image_bytes, np.uint8)
        image = cv2.imdecode(np_array, cv2.IMREAD_COLOR)

        if image is not None:
            cv2.imshow(WINDOW_NAME, image)
            
            # Wajib ada waitKey untuk me-refresh jendela OpenCV
            if cv2.waitKey(1) & 0xFF == ord('q'):
                print("Pengguna menutup jendela.")
                client.disconnect()
                cv2.destroyAllWindows()
        else:
            print(f"⚠️ Gagal mendekode gambar ({len(image_bytes)} bytes).")
    except Exception as e:
        print(f"Error processing image: {e}")

# --- Fungsi Utama ---
if __name__ == "__main__":
    
    # Buat jendela OpenCV
    cv2.namedWindow(WINDOW_NAME, cv2.WINDOW_NORMAL)
    
    client = mqtt.Client(client_id=CLIENT_ID, callback_api_version=CallbackAPIVersion.VERSION2)
    
    # Setup Callback
    client.on_connect = on_connect
    client.on_message = on_message

    # Setup Username dan Password
    client.username_pw_set(MQTT_USER, MQTT_PASSWORD)
    
    ca_cert_file = None

    # --- Blok Konfigurasi SSL ---
    if USE_MQTT_SSL:
        print("🔒 Mode SSL diaktifkan.")
        try:
            # Buat file CA sementara dari string di atas
            with tempfile.NamedTemporaryFile(delete=False, suffix=".pem") as cert_file:
                cert_file.write(ROOT_CA_CERT.encode('utf-8'))
                ca_cert_file = cert_file.name
            
            print(f"📄 Sertifikat CA sementara dibuat di: {ca_cert_file}")
            
            # Konfigurasikan TLS/SSL
            client.tls_set(
                ca_certs=ca_cert_file,
                cert_reqs=ssl.CERT_REQUIRED,
                tls_version=ssl.PROTOCOL_TLS_CLIENT
            )
        except Exception as e:
            print(f"❌ Error saat mengatur SSL: {e}")
            if ca_cert_file and os.path.exists(ca_cert_file):
                os.remove(ca_cert_file) # Hapus jika gagal
            exit()
    else:
        print("🔓 Mode Non-SSL.")
    # --- Akhir Blok SSL ---

    try:
        print(f"⏳ Mencoba menghubungkan ke {MQTT_SERVER}:{MQTT_PORT}...")
        client.connect(MQTT_SERVER, MQTT_PORT, 60)
        
        # Loop blocking untuk memproses trafik jaringan
        client.loop_forever()

    except KeyboardInterrupt:
        print("\nProgram dihentikan pengguna.")
    except Exception as e:
        print(f"\n[ERROR] Terjadi kesalahan: {e}")
    finally:
        # --- Pembersihan ---
        cv2.destroyAllWindows()
        if ca_cert_file and os.path.exists(ca_cert_file):
            os.remove(ca_cert_file)
            print(f"🗑️ Sertifikat CA sementara dihapus.")