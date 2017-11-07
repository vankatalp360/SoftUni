import java.util.Scanner;
import java.util.TreeMap;

public class SumsbyTown {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int number = Integer.parseInt(scan.nextLine());

        TreeMap<String, Double> townsRecord =
                new TreeMap<String, Double>();


        for (int i = 1 ; i <= number ; i++){
            String[] tokens = scan.nextLine().split("\\|");
            String town = tokens[0].trim();
            double quantity = Double.parseDouble(tokens[1].trim());

            if(!townsRecord.containsKey(town)) {
                townsRecord.put(town,quantity);
            }
            else {
                townsRecord.put(town, townsRecord.get(town)+quantity);
            }
        }
        for(String town :townsRecord.keySet()){
            System.out.println(town+" -> "+townsRecord.get(town));
        }
    }
}
