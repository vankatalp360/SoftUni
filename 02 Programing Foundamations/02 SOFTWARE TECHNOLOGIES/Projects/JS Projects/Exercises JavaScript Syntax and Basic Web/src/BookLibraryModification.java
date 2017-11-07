import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Scanner;

public class BookLibraryModification {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        ArrayList<Book> thisLibBooks = new ArrayList<>();

        int number = Integer.parseInt(scanner.nextLine());

        for (int i = 1; i <= number; i++) {
            String[] input = scanner.nextLine().split(" ");
            Book thisBook = ReadThisBook(input);
            thisLibBooks.add(thisBook);
        }

        Date defDate = ReadDate(scanner.nextLine());

        HashMap<String, Date> sortedBooks = DetermineAutorsTotalPrices(thisLibBooks, defDate);

        SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");

        sortedBooks.entrySet().stream().sorted((e1, e2) -> {
            int result = e1.getValue().compareTo(e2.getValue());

            if (result == 0) {
                result = e1.getKey().compareTo(e2.getKey());
            }

            return result;
        })
                .forEach(e -> {
                    System.out.printf("%s -> %s\n", e.getKey(), dateFormat.format(e.getValue()));
                });


    }

    private static HashMap<String, Date> DetermineAutorsTotalPrices(ArrayList<Book> thisLibBooks, Date defDate) {
        HashMap<String, Date> sortedBooks = new HashMap<>();
        for (Book book : thisLibBooks) {

            Date currentDate = book.getReleaseDate();

            if (defDate.before(currentDate)) {
                sortedBooks.put(book.getTitle(), book.getReleaseDate());
            }
        }
        return sortedBooks;
    }

    private static Book ReadThisBook(String[] input) {
        Book currentBook = new Book();
        currentBook.title = input[0];
        currentBook.author = input[1];
        currentBook.publisher = input[2];
        currentBook.releaseDate = ReadDate(input[3]);
        currentBook.ISBN = input[4];
        currentBook.price = Double.parseDouble(input[5]);

        return currentBook;
    }

    private static Date ReadDate(String input) {

        try {
            SimpleDateFormat df = new SimpleDateFormat("dd.MM.yyyy");
            Date result = df.parse(input);
            return result;
        } catch (ParseException pe) {
            pe.printStackTrace();
        }
        return null;
    }

    public static class Book {
        private String title;
        private String author;
        private String publisher;
        private Date releaseDate;
        private String ISBN;
        private Double price;

        public Book() {
        }

        public Book(String title, String author, String publisher, Date releaseDate, String ISBN, Double price) {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.releaseDate = releaseDate;
            this.ISBN = ISBN;
            this.price = price;
        }

        public String getTitle() {
            return title;
        }

        public void setTitle(String title) {
            this.title = title;
        }

        public String getAuthor() {
            return author;
        }

        public void setAuthor(String author) {
            this.author = author;
        }

        public String getPublisher() {
            return publisher;
        }

        public void setPublisher(String publisher) {
            this.publisher = publisher;
        }

        public Date getReleaseDate() {
            return releaseDate;
        }

        public void setReleaseDate(Date releaseDate) {
            this.releaseDate = releaseDate;
        }

        public String getISBN() {
            return ISBN;
        }

        public void setISBN(String ISBN) {
            this.ISBN = ISBN;
        }

        public Double getPrice() {
            return price;
        }

        public void setPrice(Double price) {
            this.price = price;
        }
    }
}
