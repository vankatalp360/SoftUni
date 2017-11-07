import java.util.Arrays;
import java.util.Scanner;

public class EqualSums {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] array = Arrays
                .stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        boolean result = false;
        for (int i = 0; i <= array.length; i++)
        {
            int LeftSum = CalculateLeftSum(array, i);
            int RightSum = CalculateRightSum(array, i);
            if (RightSum == LeftSum)
            {
                result = true;
                System.out.printf("%d",i);
            }
        }
        if (!result) System.out.printf("no");
    }
    private static int CalculateLeftSum(int[] array, int pos)
    {
        int Sum = 0;
        for (int i = pos - 1; i >= 0; i--)
        {
            Sum += array[i];
        }
        return Sum;
    }
    private static int CalculateRightSum(int[] array, int pos)
    {
        int Sum = 0;
        for (int i = pos + 1; i < array.length; i++)
        {
            Sum += array[i];
        }
        return Sum;
    }
}
