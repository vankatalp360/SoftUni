import java.util.*;
import java.util.stream.Collectors;

public class AverageGrades {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int members = Integer.parseInt(scanner.nextLine());

        ArrayList<Student> students = new ArrayList<Student>();
        for (int i = 1; i <= members; i++) {
            Student newStudent = ReadStudent(scanner.nextLine());
            newStudent.AverageGrades=newStudent.getAverageGrades();
            if (newStudent.AverageGrades >= 5.00) {
                students.add(newStudent);
            }
        }

        Collections.sort(students, new Comparator<Student>() {
            @Override
            public int compare(Student o1, Student o2) {
                int result = o1.Name.compareTo(o2.Name);

                if (result==0){
                    result = Double.compare(o2.AverageGrades,o1.AverageGrades);
                }
                return result;            }
        });
        for (Student student : students)
        {
            System.out.printf("%s -> %.2f%n", student.Name, student.AverageGrades);
        }
    }

    private static Student ReadStudent(String text) {
        String[] input = text.split(" ");
        String name = input[0];
        List<Double> numbers = Arrays.stream(input).skip(1).map(Double::parseDouble).collect(Collectors.toList());
        Student current = new Student();
        current.Name = name;
        current.Grades = numbers;
        return current;
    }

    public static class Student {
        public String Name;
        public List<Double> Grades;
        public Double AverageGrades;

        public Student() {
        }

        public Student(String name, List<Double> grades, Double averageGrades) {
            Name = name;
            Grades = grades;
            AverageGrades = averageGrades;
        }

        public String getName() {
            return Name;
        }

        public void setName(String name) {
            Name = name;
        }

        public List<Double> getGrades() {
            return Grades;
        }

        public void setGrades(List<Double> grades) {
            Grades = grades;
        }

        public Double getAverageGrades() {
            double AverageGrades = this.Grades
                    .stream()
                    .mapToDouble(a->a)
                    .average()
                    .getAsDouble();
            return AverageGrades;
        }

        public void setAverageGrades(Double averageGrades) {
            AverageGrades = averageGrades;
        }
    }
}
