package SoftUniBlog.controller;

import SoftUniBlog.bindingModel.CommentBindingModel;
import SoftUniBlog.entity.Article;
import SoftUniBlog.entity.Comment;
import SoftUniBlog.entity.User;
import SoftUniBlog.repository.ArticleRepository;
import SoftUniBlog.repository.CommentRepository;
import SoftUniBlog.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.ArrayList;
import java.util.List;

@Controller
public class CommentController {

    @Autowired
    private ArticleRepository articleRepository;

    @Autowired
    private UserRepository userRepository;

    @Autowired
    private CommentRepository commentRepository;


    @GetMapping("/comments/{id}")
    public String index (Model model, @PathVariable Integer id){

        if (!this.articleRepository.exists(id)) {
            return "redirect:/";
        }

        Article article = this.articleRepository.findOne(id);

       List<Comment> comments  = new ArrayList<>(article.getComments());

        model.addAttribute("view","comments/list");
        model.addAttribute("comments",comments);
        model.addAttribute("article",article);
        return "base-layout";
    }

    @GetMapping("/comments/create/{id}")
    @PreAuthorize("isAuthenticated()")
    public String create(Model model, @PathVariable Integer id) {
        if (!this.articleRepository.exists(id)) {
            return "redirect:/";
        }

        Article article = this.articleRepository.findOne(id);
        model.addAttribute("view", "comments/create");
        model.addAttribute("article",article);
        return "base-layout";
    }

    @PostMapping("/comments/create/{id}")
    @PreAuthorize("isAuthenticated()")
    public String createProcess(CommentBindingModel commentBindingModel, @PathVariable Integer id) {
        if (!this.articleRepository.exists(id)) {
            return "redirect:/";
        }

        Article article = this.articleRepository.findOne(id);
        UserDetails userDetails = (UserDetails) SecurityContextHolder.getContext()
                .getAuthentication()
                .getPrincipal();

        User user = this.userRepository.findByEmail(userDetails.getUsername());

        Comment comment = new Comment(
                commentBindingModel.getContent(),
                user,
                article
        );

        this.commentRepository.saveAndFlush(comment);

        return "redirect:/comments/"+article.getId();
    }

    @GetMapping("/comments/edit/{id}")
    @PreAuthorize("isAuthenticated()")
    public String edit(Model model, @PathVariable Integer id) {
        if (!this.commentRepository.exists(id)) {
            return "redirect:/";
        }

        Comment comment = this.commentRepository.findOne(id);
        model.addAttribute("view", "comments/edit");
        model.addAttribute("comment",comment);
        return "base-layout";
    }


    @PostMapping("/comments/edit/{id}")
    @PreAuthorize("isAuthenticated()")
    public String editProgress(CommentBindingModel commentBindingModel, @PathVariable Integer id){

        if (!this.commentRepository.exists(id)) {
            return "redirect:/";
        }

        Comment comment = this.commentRepository.findOne(id);

        comment.setContent(commentBindingModel.getContent());

        this.commentRepository.saveAndFlush(comment);

        return "redirect:/comments/"+comment.getArticle().getId();
    }

    @GetMapping("/comments/delete/{id}")
    @PreAuthorize("isAuthenticated()")
    public String delete(Model model, @PathVariable Integer id) {

        if (!this.commentRepository.exists(id)) {
            return "redirect:/";
        }

        Comment comment = this.commentRepository.findOne(id);

        model.addAttribute("comment",comment);
        model.addAttribute("view","comments/delete");

        return "base-layout";
    }

    @PostMapping("/comments/delete/{id}")
    @PreAuthorize("isAuthenticated()")
    public String editProgress(@PathVariable Integer id){

        if (!this.commentRepository.exists(id)) {
            return "redirect:/";
        }

        Comment comment = this.commentRepository.findOne(id);

        this.commentRepository.delete(comment);

        return "redirect:/";
    }
}
