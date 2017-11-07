const crypto = require('crypto');

module.exports={
    generateSalt:()=>{
       return crypto.randomBytes(128).toString('base64');
    },
    getHashedPassword:(salt,password)=>{
        return crypto.createHmac('sha256',salt).update(password).digest('hex');
    }
}