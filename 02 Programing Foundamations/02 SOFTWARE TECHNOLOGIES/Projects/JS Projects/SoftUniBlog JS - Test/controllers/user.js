const User = require('./../models/User');
const encryption = require('./../utilities/encryption');

module.exports={
    registerGet:(req,res)=>{
        res.render('user/register');
    },

    registerPost:(req,res)=>{
        let registerArgs = req.body;

        User.findOne({email:registerArgs.email}).then(user=>{
            let errorMsg ='';
            if (user)
            {
                errorMsg='User with the same email exists!';
            }
            else if (registerArgs.password!==registerArgs.repeatedPassword)
            {
                errorMsg='Passwords do not match!';
            }
            if (errorMsg)
            {
                registerArgs.error=errorMsg;
                res.render('user/register',registerArgs);
            }
            else
            {
                let salt = encryption.generateSalt();
                let passwordHash = encryption.getHashedPassword(salt,registerArgs.password);
                let userObject = {
                    email:registerArgs.email,
                    passwordHash:passwordHash,
                    fullName:registerArgs.fullName,
                    salt:salt
                };
                User.create(userObject).then(user=>{
                    req.logIn(user,(err)=>{
                        if (err){
                            registerArgs.error=err.message;
                            res.redirect('user/register',registerArgs);
                            return;
                        }
                        res.redirect('/');
                    })
                })

            }
        })


    }
}