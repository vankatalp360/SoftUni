package SoftUniBlog.config;

import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.AuthorityUtils;
import org.springframework.security.core.userdetails.UserDetails;
import SoftUniBlog.entity.User;
import org.springframework.util.StringUtils;

import java.util.ArrayList;
import java.util.Collection;

public class BlogUserDetails extends User implements UserDetails{

    private ArrayList<String> roles;

    private User user;

    @Override
    public boolean isAccountNonExpired(){return true;}

    @Override
    public boolean isAccountNonLocked(){return true;}

    @Override
    public boolean isCredentialsNonExpired(){return true;}

    @Override
    public boolean isEnabled(){return true;}

    public BlogUserDetails(ArrayList<String> roles, User user) {
        super(user.getEmail(),user.getFullName(),user.getPassword());
        this.roles = roles;
        this.user = user;
    }

    @Override
    public Collection<?extends GrantedAuthority> getAuthorities(){
        String userRoles = StringUtils.collectionToCommaDelimitedString(this.roles);
        return AuthorityUtils.commaSeparatedStringToAuthorityList(userRoles);
    }

    public User getUser() {
        return this.user;
    }

    @Override
    public String getUsername() {
        return this.user.getEmail();
    }
}
