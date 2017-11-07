import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;

public class PhonebookUpgrade {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        TreeMap<String, String> phoneBook = new TreeMap<>();

        while (true) {

            String input = scanner.nextLine();

            if (input.equals("END")) return;

            else if (input.equals("ListAll")){
                for (String key : phoneBook.keySet()) {
                    System.out.println(key + " -> " + phoneBook.get(key));
                }

            }

            String[] elements = input.split(" ");

            if (elements[0].equals("A")) {

                String name = elements[1];

                String number = elements[2];

                phoneBook.put(name, number);

            } else if (elements[0].equals("S")) {

                String name = elements[1];

                String number = phoneBook.get(name);

                if (number != null) {
                    System.out.printf("%s -> %s%n", name, number);
                } else {
                    System.out.printf("Contact %s does not exist.%n", name);
                }
            }
        }
    }
}
