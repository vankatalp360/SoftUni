import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.IntStream;

public class VowelorDigit {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        char[] input = scanner.nextLine().toLowerCase().toCharArray();

        String[] vowel = {"a", "e", "o", "u", "i", "y"};

        String result = null;

        for (char ch : input) {

            int ascii = (int) ch;

            if (ascii >= 48 && ascii <= 57) {
                result = "digit";
            } else if (useList(vowel,String.valueOf(ch))) {
                result = "vowel";
            } else {
                result = "other";
            }

            System.out.println(result);
        }
    }

    public static boolean useList(String [] arr, String targetValue) {
        return Arrays.asList(arr).contains(targetValue);
    }
}
