import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class Bomb_Numbers {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] nums = scanner.nextLine().split(" ");
        int[] anchors = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        List<Integer> numbers = new ArrayList<Integer>();
        for(String num:nums){
            numbers.add(Integer.parseInt(num));
        }

       for(int i = 0 ; i < numbers.size();i++){

            if (numbers.get(i) ==Integer.valueOf(anchors[0])){
                for(int j =0 ; j <=anchors[1];j++){
                    if (i-j>=0){
                        numbers.set(i-j,0);
                    }
                }
                for(int j =0 ; j <=anchors[1];j++){
                    if (i+j<numbers.size()){
                        numbers.set(i+j,0);
                    }
                }
                i+=anchors[1];
            }
       }



        Integer sum = 0;
        for(Integer num : numbers){
            sum+=num;
        }
        //System.out.println(numbers);
        System.out.println(sum);
    }
}
