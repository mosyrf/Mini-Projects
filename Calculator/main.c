#include <stdio.h>
#include <stdlib.h>
#include <math.h>

void menu();
void hitung();

    int option, reset;
    float firstNumber, secondNumber, result;
    FILE *writeTOtxt;                                                                   

int main()
{
    writeTOtxt =  fopen("SIMPAN.txt", "w");                                             
    fprintf(writeTOtxt, "Berikut Ini Adalah Riwayat Operasi Yang Dilakukan\n");         
    fclose(writeTOtxt);                                                                  

    menu();
    printf("MASUKKAN PILIHAN ANDA (1 - 4): ");
    scanf("%d", &option);
    hitung();

    printf("\n===================================\n");
    printf("APAKAH ANDA INGIN MELAKUKAN OPERASI LAIN ?");
    printf("\n\tYA = 1\t\tTIDAK = 0");
    printf("\n===================================");
    printf("\n\tMASUKKAN PILIHAN: ");
    scanf("%d", &reset);

    if(reset == 1)
        {
    while(reset == 1)
    {
        //system("cls");
        menu();
        printf("MASUKKAN PILIHAN ANDA: ");
        scanf("%d", &option);
        hitung();

        printf("\n===================================\n");
        printf("APAKAH ANDA INGIN MELAKUKAN OPERASI LAIN ?");
        printf("\n\tYA = 1\tTIDAK = 0");
        printf("\n===================================");
        printf("\n\tMASUKKAN PILIHAN: ");
        scanf("%d", &reset);
    }
        }else
        {
        printf("\n==============SELESAI==============\n");
        }



    return 0;
}

    void hitung()
    {
     switch(option)
     {
        case 1:
            //system("cls");
            printf("\tOperasi Penjumlahan\n");
            printf("===================================\n");

            printf("MASUKKAN ANGKA PERTAMA: ");
            scanf("%f", &firstNumber);
            printf("MASUKKAN ANGKA KEDUA: ");
            scanf("%f", &secondNumber);

            result = firstNumber + secondNumber;
            printf("resultnya Adalah: %.2f", result);

            writeTOtxt =  fopen("SIMPAN.txt", "a");
            fprintf(writeTOtxt, "Operasi Yang Dilakukan Adalah Penjumlahan\n");
            fprintf(writeTOtxt, "%.2f + %.2f\n", firstNumber, secondNumber);
            fprintf(writeTOtxt, "result Operasi: %.2f\n\n", result);
            fclose(writeTOtxt);
            break;
        case 2:
            //system("cls");
            printf("\tOperasi Pengurangan\n");
            printf("===================================\n");

            printf("MASUKKAN ANGKA PERTAMA: ");
            scanf("%f", &firstNumber);
            printf("MASUKKAN ANGKA KEDUA: ");
            scanf("%f", &secondNumber);
            result = firstNumber - secondNumber;

            printf("resultnya Adalah: %.2f", result);

            writeTOtxt =  fopen("SIMPAN.txt", "a");
            fprintf(writeTOtxt, "Operasi Yang Dilakukan Adalah Pengurangan\n");
            fprintf(writeTOtxt, "%.2f - %.2f\n", firstNumber, secondNumber);
            fprintf(writeTOtxt, "result Operasi: %.2f\n\n", result);
            fclose(writeTOtxt);
            break;
        case 3:
            //system("cls");
            printf("\tOperasi Perkalian\n");
            printf("===================================\n");

            printf("MASUKKAN ANGKA PERTAMA: ");
            scanf("%f", &firstNumber);
            printf("MASUKKAN ANGKA KEDUA: ");
            scanf("%f", &secondNumber);

            result = firstNumber * secondNumber;
            printf("resultnya Adalah: %.2f", result);

            writeTOtxt =  fopen("SIMPAN.txt", "a");
            fprintf(writeTOtxt, "Operasi Yang Dilakukan Adalah Perkalian\n");
            fprintf(writeTOtxt, "%.2f * %.2f\n", firstNumber, secondNumber);
            fprintf(writeTOtxt, "result Operasi: %.2f\n\n", result);
            fclose(writeTOtxt);
            break;
        case 4:
            //system("cls");
            printf("\tOperasi Pembagian\n");
            printf("===================================\n");

            printf("MASUKKAN ANGKA PERTAMA: ");
            scanf("%f", &firstNumber);
            printf("MASUKKAN ANGKA KEDUA: ");
            scanf("%f", &secondNumber);

            result = firstNumber / secondNumber;
            printf("resultnya Adalah: %.2f", result);

            writeTOtxt =  fopen("SIMPAN.txt", "a");
            fprintf(writeTOtxt, "Operasi Yang Dilakukan Adalah Pembagian\n");
            fprintf(writeTOtxt, "%.2f / %.2f\n", firstNumber, secondNumber);
            fprintf(writeTOtxt, "result Operasi: %.2f\n\n", result);
            fclose(writeTOtxt);

            break;
        default:
            //system("cls");
            printf("Anda Salah Memilih Nomor");
    }
    }

    void menu()
    {
        printf("============================================================\n");
        printf("\t\tPROGRAM KALKULATOR SEDERHANA\n");
        printf("============================================================\n");
        printf("\t\t\tPILIH MENU\n");
        printf("\t1. PENJUMLAHAN\n");
        printf("\t2. PENGURANGAN\n");
        printf("\t3. PERKALIAN\n");
        printf("\t4. PEMBAGIAN\n");
        printf("============================================================\n");
    }

