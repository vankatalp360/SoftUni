import java.io.Console;
import java.util.Scanner;

public class IndexofLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        char[] array = new char[26];
        int j = 0;
        for (char a = 'a'; a <= 'z'; a++)
        {
            array[j] = a;
            j++;
        }
        char[] word = scanner.nextLine().toCharArray();
        for (int i = 0; i < word.length; i++)
        {
            for (int b = 0; b < array.length; b++)
            {
                if (word[i] == array[b])
                    System.out.printf("%c -> %d%n",word[i],b);
            }
        }
    }
}
