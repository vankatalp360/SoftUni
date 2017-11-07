const Article = require('mongoose').model('Article');

module.exports = {
    createGet: (req, res) => {
        res.render('article/create');
    },
    createPost: (req, res) => {
            const articleArgs = req.body;
        let errorMsg = '';
        if (!req.isAuthenticated()) {
            errorMsg = 'You should be logged in to make articles! Please log in!';
        } else if (!articleArgs.title) {
            errorMsg = 'Invalid title! Please fill correct title!';
        } else if (!articleArgs.content) {
            errorMsg = 'Invalid content! Please fill content!';
        }
        if (errorMsg) {
            res.render('article/create', {error: errorMsg});
            return;
        }
        let image = req.files.image;

        if(image){
            let randomChar = require('./../utilities/encryption').generateSalt().substr(0,5);

            let fileName =`${articleArgs.title}+${randomChar}+${image.name}`;
            image.mv(`./public/images/${fileName}`,err=>{
               if(err){
                   res.redirect('/', {error: err.message});
               }
            });
            articleArgs.imagesPath=`/images/${fileName}`;
        }


        articleArgs.author = req.user.id;
        Article.create(articleArgs).then(article => {
            req.user.articles.push(article.id);
            req.user.save(err => {
                if (err) {
                    res.redirect('/', {error: err.message});
                } else {
                    res.redirect('/');
                }
            });
        })
    },

    details: (req, res) => {
        let id = req.params.id;
        Article.findById(id).populate('author').then(article => {
            const moment = require('moment');
            let formattedDate = moment(article.date).format("YYYY-MM-DD");
            article.formattedDate = formattedDate;

            if (!req.user){
                article.userModifierRight=false;
                res.render('article/details', article);

            }else {
                req.user.isInRole('Admin').then(isAdmin=>{
                    let userModifierRight=isAdmin||req.user.isAuthor(article);
                    article.userModifierRight=userModifierRight;
                    res.render('article/details',article);
                });
            }
        });
    },

    editGet:(req,res)=>{
        let id = req.params.id;

        Article.findById(id).then(article=>{
            if (!req.user){
                res.render('home/index',{error:'You can not edit this article! // Please login!'});
                return;
            }
            req.user.isInRole('Admin').then(isAdmin=>{
                if (!req.user.isAuthor(article)&&!isAdmin){
                    res.render('home/index',{error:'You can not edit this article! // You are not its author or admin!'});
                    return;
                }
                res.render('article/edit',article);
            });
        });
    },
    editPost:(req,res)=>{
        let id = req.params.id;

        const articleArgs = req.body;

        let errorMsg = '';
        if (!articleArgs.title) {
            errorMsg = 'Invalid title! Article title can not be empty!';
        } else if (!articleArgs.content) {
            errorMsg = 'Invalid content! Article content can not be empty!';
        }
        if (errorMsg) {
            res.render('article/edit', {error: errorMsg});
        }else{
            Article.update({_id:id},{$set:{title:articleArgs.title,content:articleArgs.content}}).then(updateStatus =>{
                res.redirect(`/article/details/${id}`);
            });

        }

    },

    deleteGet:(req,res)=>{
        let id = req.params.id;

        Article.findById(id).then(article=>{
            if (!req.user){
                res.render('home/index',{error:'You can not delete this article! // Please login!'});
                return;
            }
            req.user.isInRole('Admin').then(isAdmin=>{
                if (!req.user.isAuthor(article)&&!isAdmin){
                    res.render('home/index',{error:'You can not delete this article! // You are not its author or admin!'});
                    return;
                }
                res.render('article/delete',article);
            });
        });
    },
    deletePost:(req,res)=>{
        let id = req.params.id;

        Article.findOneAndRemove({_id:id}).populate('author').then(article=>{
           let author = article.author;

           let index = author.articles.indexOf(article.id);

           if(index<0){
               let errorMsg = 'Article was not found for that author!';
               res.render('article/delete',{error:errorMsg});
           }else {
               let count =1;
               author.articles.splice(index,count);
               author.save().then((user)=>{
                   res.redirect('/');
               });
           }

        });

    }
};