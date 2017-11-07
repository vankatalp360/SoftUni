import java.util.Arrays;
import java.util.Scanner;

public class BombNumbers {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] inputLetter = Arrays
                .stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();
        int[] bumbAndPower = Arrays
                .stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int Bumb = bumbAndPower[0];
        int Power = bumbAndPower[1];
        boolean[] ConvertedList = new boolean[inputLetter.length];
        for (int i = 0; i < inputLetter.length; i++)
        {
            if (ConvertedList[i] == false && inputLetter[i] == Bumb)
            {
                for (int j = 0; j <= Power; j++)
                {
                    if (i - j >= 0) ConvertedList[i - j] = true;
                    if (i + j < inputLetter.length) ConvertedList[i + j] = true;
                }
            }
        }
        int Sum = 0;
        for (int i = 0; i < inputLetter.length; i++)
        {
            if (ConvertedList[i] == false) Sum += inputLetter[i];
        }
        System.out.println(Sum);
    }
}
