//const Task = require('../models/Task');
const Task = require('mongoose').model('Task');

module.exports = {
    index: (req, res) => {
        Task.find().then(tasks=>{
            res.render('task/index', {'tasks': tasks});
        }).catch(err => {
            res.render('tack/index', {error: err.message})
        });
    },
	createGet: (req, res) => {
        res.render('task/create');
	},
	createPost: (req, res) => {
        const taskArgs = req.body;
        let errorMsg = '';
        if (!taskArgs.title) {
            errorMsg = 'Invalid title! Please fill correct title!';
        } else if (!taskArgs.comments) {
            errorMsg = 'Invalid comments! Please fill comments!';
        }
        if (errorMsg) {
            res.render('task/create', {error: errorMsg});
            return;
        }

        Task.create(taskArgs).then(task=>{
            res.redirect('/');
        }).catch(err => {
            taskArgs.error = 'Can not create task! Invalid task! Please full fill the form!';
            res.render('tack/create',  taskArgs)
        });
	},
	deleteGet: (req, res) => {
        let id = req.params.id;
        // if (!id){
        //     res.redirect('/');
        //     return;
        // }

        Task.findById(id).then(task=>{
            if (!task){
                res.redirect('/');
                return;
            }
                res.render('task/delete',task);
            }).catch(err => {
            return res.redirect('/');
        });
	},
	deletePost: (req, res) => {
        let id = req.params.id;
        // if (!id){
        //     res.redirect('/');
        //     return;
        // }
        let task = req.body;

        Task.findByIdAndRemove(id).then(tasks =>{
            res.redirect('/');
        }).catch(err => {
            task.id = id;
            task.errorMsg = 'Can not delete such task! Invalid task!';
            return res.render('task/delete', task);
        });
	}
};