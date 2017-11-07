import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.Scanner;
import java.util.stream.IntStream;

public class Largest3Numbers {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] nums = Arrays
                .stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        Arrays.sort(nums);

        int[] sorted = IntStream.of(nums)
                .boxed()
                .sorted(Comparator.reverseOrder())
                .mapToInt(i -> i)
                .toArray();

        int lenght = Math.min(sorted.length,3);
        for(int i = 0 ; i < lenght;i++){
            System.out.println(sorted[i]);
        }
    }
}
