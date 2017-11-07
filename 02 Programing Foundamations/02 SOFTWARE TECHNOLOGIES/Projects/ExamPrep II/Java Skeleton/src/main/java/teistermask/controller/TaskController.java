package teistermask.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import teistermask.bindingModel.TaskBindingModel;
import teistermask.entity.Task;
import teistermask.repository.TaskRepository;

import java.util.List;

@Controller
public class TaskController {
    private final TaskRepository taskRepository;

    @Autowired
    public TaskController(TaskRepository taskRepository) {
        this.taskRepository = taskRepository;
    }

    @GetMapping("/")
    public String index(Model model) {
        List<Task> openTasks = this.taskRepository
                .findAllByStatus("Open");
        List<Task> inProgressTasks = this.taskRepository
                .findAllByStatus("In Progress");
        List<Task> finishedTasks = this.taskRepository
                .findAllByStatus("Finished");

        model.addAttribute("view", "task/index");
        model.addAttribute("openTasks", openTasks);
        model.addAttribute("inProgressTasks", inProgressTasks);
        model.addAttribute("finishedTasks", finishedTasks);

        return "base-layout";
    }

    @GetMapping("/create")
    public String create(Model model) {
        model.addAttribute("view", "task/create");
        return "base-layout";
    }

    @PostMapping("/create")
    public String createProcess(Model model, TaskBindingModel taskBindingModel) {
        if (taskBindingModel == null) {
            return "redirect:/";
        }
        if (taskBindingModel.getTitle().equals("")) {
            return "redirect:/create";
        }
        if (!taskBindingModel.getStatus().equals("Open")&&!taskBindingModel.getStatus().equals("In Progress")&&
                !taskBindingModel.getStatus().equals("Finished")) {
            return "redirect:/create";
        }

        Task taskEntity = new Task(
                taskBindingModel.getTitle(),
                taskBindingModel.getStatus()
        );

        this.taskRepository.saveAndFlush(taskEntity);

               return "redirect:/";
    }

    @GetMapping("/edit/{id}")
    public String edit(Model model, @PathVariable int id) {
        if (!this.taskRepository.exists(id)) {
            return "redirect:/";
        }

        Task task = this.taskRepository.findOne(id);

        if (task == null) {
            return "redirect:/";
        }

        model.addAttribute("task", task);
        model.addAttribute("view", "task/edit");

        return "base-layout";
    }



    @PostMapping("/edit/{id}")
    public String editProcess(@PathVariable int id, TaskBindingModel taskBindingModel) {

        if(!this.taskRepository.exists(id)){
            return "redirect:/";
        }

        if (taskBindingModel.getTitle().equals("")||(!taskBindingModel.getStatus().equals("Open")&&!taskBindingModel.getStatus().equals("In Progress")
                &&!taskBindingModel.getStatus().equals("Finished")) ) {
            return "redirect:/create";
        }


        Task task = this.taskRepository.findOne(id);

        if (task == null) {
            return "redirect:/";
        }

        task.setTitle(taskBindingModel.getTitle());
        task.setStatus(taskBindingModel.getStatus());
        this.taskRepository.saveAndFlush(task);

        return "redirect:/";
    }
}
