import javafx.util.converter.IntegerStringConverter;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

public class BookLibrary {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Library mylibrary = new Library();
        mylibrary.name = "myLibrary";
        ArrayList<Book> thisLibBooks = new ArrayList<>();

        int number = Integer.parseInt(scanner.nextLine());

        for (int i = 1; i <= number; i++) {
            String[] input = scanner.nextLine().split(" ");
            Book thisBook = ReadThisBook(input);
            thisLibBooks.add(thisBook);
        }

        mylibrary.books = thisLibBooks;

        HashMap<String, Double> authors = DetermineAutorsTotalPrices(thisLibBooks);


        authors.entrySet().stream().sorted((e1, e2) -> {
            int result = Double.compare(e2.getValue(), e1.getValue());

            if (result == 0) {
                result = e1.getKey().compareTo(e2.getKey());
            }

            return result;
        })
                .forEach(e -> {
                    System.out.printf("%s -> %.2f\n", e.getKey(), e.getValue());
                });


    }

    private static HashMap<String, Double> DetermineAutorsTotalPrices(ArrayList<Book> thisLibBooks) {
        HashMap<String, Double> authors = new HashMap<>();
        for (Book book : thisLibBooks) {
            Double count = authors.get(book.author);
            if (count == null)
                count = 0D;
            authors.put(book.author, count + book.price);
        }
        return authors;
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
            DateFormat df = new SimpleDateFormat("dd.MM.yyyy");
            Date result = df.parse(input);
            return result;
        } catch (ParseException pe) {
            pe.printStackTrace();
        }
        return null;
    }

    public static class Book {
        public String title;
        public String author;
        public String publisher;
        public Date releaseDate;
        public String ISBN;
        public Double price;

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

    public static class Library {
        public String name;
        public ArrayList<Book> books;

        public Library() {
        }

        public Library(String name, ArrayList<Book> books) {
            this.name = name;
            this.books = books;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public ArrayList<Book> getBooks() {
            return books;
        }

        public void setBooks(ArrayList<Book> books) {
            this.books = books;
        }
    }

}
