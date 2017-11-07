import java.util.Arrays;
import java.util.Scanner;

public class MostFrequentNumber {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int[] sequance = Arrays
                .stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();
  int maxStart = sequance[0];
        int maxLen = 1;


        for (int i = 0; i < sequance.length; i++) {
            int currentStart = sequance[i];
            int currentLen = 1;
            for (int j = i + 1; j < sequance.length; j++) {

                if (sequance[i] == sequance[j]) currentLen++;
            }
            if (currentLen > maxLen) {
                maxStart = currentStart;
                maxLen = currentLen;
            }
        }

        System.out.println(maxStart);
    }
}

