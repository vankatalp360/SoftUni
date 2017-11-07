package shoppinglist.entity;

import javax.persistence.*;

@Entity
@Table(name = "products")
public class Product {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    private Integer priority;

    private String name;

    private Integer quantity;

    private String status;

    @Column(nullable = false)
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getPriority() {
        return priority;
    }

    @Column(nullable = false, name = "priority")
    public void setPriority(Integer priority) {
        if(quantity!=0){
            this.priority = priority;
        }
        else {
            throw new IllegalArgumentException("Invalid status"+priority);
        }
    }

    public String getName() {
        return name;
    }

    @Column(nullable = false, name = "name")
    public void setName(String name) {
        if(!name.equals("")){
            this.name = name;
        }
        else {
            throw new IllegalArgumentException("Invalid status"+name);
        }
    }

    public Integer getQuantity() {
        return quantity;
    }

    @Column(nullable = false, name = "quantity")
    public void setQuantity(Integer quantity) {
        if(quantity!=0){
            this.quantity = quantity;
        }
        else {
            throw new IllegalArgumentException("Invalid status"+quantity);
        }
    }

    public String getStatus() {
        return status;
    }

    @Column(nullable = false, name = "status")
    public void setStatus(String status) {
        if(status.equals("bought")||status.equals("not bought")){
            this.status = status;
        }
        else {
            throw new IllegalArgumentException("Invalid status"+status);
        }
    }

    public Product(Integer priority, String name, Integer quantity, String status) {
        this.priority = priority;
        this.name = name;
        this.quantity = quantity;
        this.status = status;
    }

    public Product() {
    }
}
