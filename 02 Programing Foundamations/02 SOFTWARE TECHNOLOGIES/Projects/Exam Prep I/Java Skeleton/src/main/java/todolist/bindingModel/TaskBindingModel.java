package todolist.bindingModel;
import javax.validation.constraints.NotNull;


public class TaskBindingModel {

    private String title;

    private String comments;

    public TaskBindingModel() {
    }

    public TaskBindingModel(String title, String comments) {
        this.title = title;
        this.comments = comments;
    }

    @NotNull
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    @NotNull
    public String getComments() {
        return comments;
    }

    public void setComments(String comments) {
        this.comments = comments;
    }
}
