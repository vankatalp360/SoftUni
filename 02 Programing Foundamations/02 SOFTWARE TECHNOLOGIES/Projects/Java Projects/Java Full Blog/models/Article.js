const mongoose = require('mongoose');

let articleShema = mongoose.Schema({
    title:{type:String,required:true},
    content:{type:String, required:true},
    author:{type:mongoose.Schema.Types.ObjectId, required:true,ref:'User'},
    date:{type:Date,default:Date.now()},
    imagesPath:{type:String}
});

articleShema.method({
    trimContent:function () {
        return this.content=this.content.substr(0,100)+'...';
    }
});

const Article = mongoose.model('Article',articleShema);

module.exports = Article;