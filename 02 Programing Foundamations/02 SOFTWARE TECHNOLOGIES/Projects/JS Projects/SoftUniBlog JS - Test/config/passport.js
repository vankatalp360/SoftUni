const passport = require('passport');
const LocalPassport = require('passport-local');
const User = require('./../models/User');

const authentificateUser =(username, password , done) =>{
    User.findOne({email:username}).then(user=>{
        if (!user)
        {
            return done(null, false);
        }
        if (!user.authentificate(password)){
            return done(null,false);
        }
        return done (null,user);
    })
}

module.exports=()=>{
    passport.use(new LocalPassport({
        _usernameField:'email',
        _passwordField:'password',
    },authentificateUser));
    
}