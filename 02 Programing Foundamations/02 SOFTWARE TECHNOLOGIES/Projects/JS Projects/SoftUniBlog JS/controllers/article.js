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

            res.render('article/details', article);
        });
    }
};