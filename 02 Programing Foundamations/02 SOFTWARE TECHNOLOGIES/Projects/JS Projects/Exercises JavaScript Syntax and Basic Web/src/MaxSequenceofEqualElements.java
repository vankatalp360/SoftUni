import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.Arrays;

public class MaxSequenceofEqualElements {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int [] array = Arrays
                .stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        ArrayList<Integer> thelongestSubsequence = new ArrayList<Integer>();
        ArrayList<Integer> currentSubsequence = new ArrayList<Integer>();
        currentSubsequence.add(array[0]);
        for (int i = 1; i < array.length;i++){
            if (array[i]==array[i-1]){
                currentSubsequence.add(array[i]);
            }
            else {
                if (currentSubsequence.size()>thelongestSubsequence.size())
                {
                    thelongestSubsequence.clear();
                    for(int k : currentSubsequence)
                    {
                        thelongestSubsequence.add(k);
                    }
                }
                currentSubsequence.clear();
                currentSubsequence.add(array[i]);
            }
        }
        if (currentSubsequence.size() > thelongestSubsequence.size())
        {
            thelongestSubsequence.clear();
            for (int k : currentSubsequence)
            {
                thelongestSubsequence.add(k);
            }
        }

        String formatedResult = thelongestSubsequence.toString().replaceAll("[\\[\\],]+","");
        System.out.println(formatedResult);

    }
}
