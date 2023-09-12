//Be användaren om en sträng
Console.WriteLine("Skriv in en sträng med siffror och andra tecken: ");
//Ta emot strängen från användaren och spara som input
string input = Console.ReadLine();

//Lägg till en tom rad efter användarinput för tydlighet
Console.WriteLine();

//Skapa plats1 och plats2 för att kunna spara index där vi hittar likadana siffror
int plats1 = 0;
int plats2 = 1;

//En string att spara alla characters som ska plussas ihop i (numbersBeforeParse) och en long för när characters är siffror (sumOfNumbers)
string numberBeforeParse = "";
long sumOfNumbers = 0;

//Skapa en Boolean som håller koll på om det har hittats annat än siffror i strängen
Boolean noOtherCharacters;

//För varje plats i input
for (int i = 0; i < input.Length; i++)
{
    //Se till att koden antar att input är siffor 
    noOtherCharacters = true;

    //för varje plats i input från loop plats i och framåt 
    for (int j = i + 1; j < input.Length; j++)
    {
        //Om vi hittar två likadana tecken 
        if (input[i] == input[j])
        {
            //Spara första dubblett index i Plats1 och andra index i plats2
            plats1 = i;
            plats2 = j;

            //Kalla metod som kollar om det finns annat än siffror från plats1 till plats2
            checkForOtherCharacters();

            //Om noOtherCharacters inte har ändrats gå in till PrintOut metoden och skriv ut. 
            if (noOtherCharacters == true)
            {
                PrintOut();

                //Flytta alla värden till sumOfNumbers och ändra till datatypen long
                sumOfNumbers = sumOfNumbers + long.Parse(numberBeforeParse);
                //Töm numbersBeforeParse så att den är tom för nästa värden
                numberBeforeParse = "";
                break;
            }
        }
    }
}

Console.WriteLine();
Console.WriteLine("Summan av alla talen i färger är: " + sumOfNumbers);

void checkForOtherCharacters()
{
    for (int d = plats1; d <= plats2; d++)
    {
        //Om det finns andra tecken än siffror ändra noOtherCharacters till false
        if (!char.IsDigit(input[d]))
        {
            noOtherCharacters = false;
            break;
        }
    }
}


void PrintOut()
{
    for (int b = 0; b < plats1; b++)
    {
        Console.Write(input[b]);
    }

    for (int a = plats1; a <= plats2; a++)
    {
        //Om det inte finns plats mellan indexen (de är bredvid varandra), avbryt metoden 
        if (plats2 - plats1 == 1)
        {
            break;
        }

        //Skriv ut alla värden från index plats1 tom. index plats2 i grön färg
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(input[a]);
        Console.ResetColor();

        //Spara alla utskrivna värden i numberBeforeParse
        numberBeforeParse = numberBeforeParse + input[a];
    }

    for (int c = plats2 + 1; c < input.Length; c++)
    {
        Console.Write(input[c]);
    }
    Console.WriteLine();
}