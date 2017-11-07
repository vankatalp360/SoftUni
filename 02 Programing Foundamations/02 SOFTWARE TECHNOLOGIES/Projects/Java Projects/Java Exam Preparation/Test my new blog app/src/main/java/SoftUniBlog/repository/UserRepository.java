package SoftUniBlog.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import SoftUniBlog.entity.User;

public interface UserRepository extends JpaRepository<User,Integer>{
    User findByEmail(String email);
}
