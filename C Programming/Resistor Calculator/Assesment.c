#include <stdio.h>
#include <stdlib.h>

int main()
{
    float Res1, Res2, Res3, Res4, Itotal, rSeri1, rSeri2, rParalel, Rtotal, Vs;

    printf("MASUKKAN NILAI RESISTOR 1: ");
    scanf("%f", &Res1);
    printf("MASUKKAN NILAI RESISTOR 2: ");
    scanf("%f", &Res2);
    printf("MASUKKAN NILAI RESISTOR 3: ");
    scanf("%f", &Res3);
    printf("MASUKKAN NILAI RESISTOR 4: ");
    scanf("%f", &Res4);

    printf("MASUKKAN NILAI ARUS TOTAL: ");
    scanf("%f", &Itotal);

    rSeri1 = Res1 + Res2;
    rSeri2 = Res3 + Res4;
    rParalel = (1/rSeri1) + (1 / rSeri2);
    Rtotal = 1 / rParalel;
    printf("NILAI RESISTOR TOTAL ADALAH: %f", Rtotal);

    Vs = Itotal * Rtotal;
    printf("\nNILAI TEGANGAN SUMBER ADALAH: %f", Vs);


    return 0;
}



/*int main()
{
    float Res1, Res2, Res3, Res4, Itotal, rSeri1, rSeri2, Rtotal, Vs;

    printf("MASUKKAN NILAI RESISTOR 1: ");
    scanf("%f", &Res1);
    printf("MASUKKAN NILAI RESISTOR 2: ");
    scanf("%f", &Res2);
    printf("MASUKKAN NILAI RESISTOR 3: ");
    scanf("%f", &Res3);
    printf("MASUKKAN NILAI RESISTOR 4: ");
    scanf("%f", &Res4);

    rSeri1 = Res1 + Res2;
    rSeri2 = Res3 + Res4;
    Rtotal = (rSeri1 * rSeri2) / (rSeri1 + rSeri2);
    printf("NILAI RESISTOR TOTAL ADALAH (R): %.3f", Rtotal);

    printf("\nMASUKKAN NILAI ARUS TOTAL (I): ");
    scanf("%f", &Itotal);


    printf("\n===========================================\n");

    Vs = Itotal * Rtotal;
    printf("\nNILAI TEGANGAN SUMBER ADALAH (Vs): %.3f\n", Vs);

    return 0;
}
*/
