const mongoose = require('mongoose');
const encryption = require("../utilities/encryption.js");
mongoose.connect('mongodb://localhost/test');

let userSchema = mongoose.Schema({
    email:{type:String , require:true, unique:true},
    passwordHash:{type:String,required:true},
    fullName:{type:String,required:true},
    salt:{type:String,require:true}
});

userSchema.method({
    authenticate:function (password) {
        let inputPasswordHash = encryption.getHashedPassword(this.salt,password);
        let isSamePasswordHash = inputPasswordHash===this.passwordHash;
        return isSamePasswordHash;
    }
});

const User = mongoose.model('User',userSchema);

module.exports=User;