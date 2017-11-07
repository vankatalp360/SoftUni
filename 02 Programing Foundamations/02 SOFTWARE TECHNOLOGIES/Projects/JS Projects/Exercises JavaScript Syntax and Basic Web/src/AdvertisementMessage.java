import java.util.Random;
import java.util.Scanner;

public class AdvertisementMessage {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String[] phrases =
                {"Excellent product.",
                        "Such a great product.",
                        "I always use that product.",
                        "Best product of its category.",
                        "Exceptional product.",
                        "I can't live without this product."};

        String[] еvents =
                {"Now I feel good.",
                        "I have succeeded with this product.",
                        "Makes miracles. I am happy of the results!",
                        "I cannot believe but now I feel awesome.",
                        "Try it yourself, I am very satisfied.",
                        "I feel great!"};

        String[] author =
                {"Diana",
                        "Petya",
                        "Stella",
                        "Elena",
                        "Katya",
                        "Iva",
                        "Annie",
                        "Eva"};

        String[] cities  =
                {"Burgas",
                        "Sofia",
                        "Plovdiv",
                        "Varna",
                        "Ruse"};

        int number = Integer.parseInt(scanner.nextLine());
        Random generator = new Random();
        for (int i =1 ; i <= number; i++){

            int phrasesRm = generator.nextInt(phrases.length);
            int еventsRm = generator.nextInt(еvents.length);
            int authorRm = generator.nextInt(author.length);
            int cityRm = generator.nextInt(cities.length);
            String result = phrases[phrasesRm]+" "+еvents[еventsRm]+" "+author[authorRm]+" - "+cities[cityRm];

            System.out.println(result);

        }
    }
}
