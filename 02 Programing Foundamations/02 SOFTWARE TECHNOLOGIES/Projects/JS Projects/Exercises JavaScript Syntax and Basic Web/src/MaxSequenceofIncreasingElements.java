import java.util.Arrays;
import java.util.Scanner;

public class MaxSequenceofIncreasingElements {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] sequance = Arrays
                .stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int maxStart = 0;
        int maxLen = 1;
        int currentStart = 0;
        int currentLen = 1;

        for (int i = 1; i < sequance.length; i++) {
            if (sequance[i] > sequance[i - 1]) {
                currentLen++;
                if (currentLen > maxLen) {
                    maxLen = currentLen;
                    maxStart = currentStart;
                }
            } else {
                currentStart = i;
                currentLen = 1;
            }
        }
        String result = "";

        for (int i = maxStart; i < maxStart + maxLen; i++)
        {
            result+=sequance[i]+" ";
        }

        System.out.println(result);
    }
}
