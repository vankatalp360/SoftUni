import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Scanner;

public class Phonebook {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        LinkedHashMap<String, String> phoneBook = new LinkedHashMap<>();

        while (true){

            String input = scanner.nextLine();

            if (input.equals("END")) return;

            String[] elements = input.split(" ");

            if (elements[0].equals("A")){

                String name = elements[1];

                String number = elements[2];

                phoneBook.put(name,number);

            }
            else if(elements[0].equals("S")){

                String name = elements[1];

                String number = phoneBook.get(name);

                if (number!=null){
                    System.out.printf("%s -> %s%n",name,number);
                }
                else {
                    System.out.printf("Contact %s does not exist.%n",name);
                }

            }
        }
    }
}
