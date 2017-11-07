const Product = require('../models/Product');

module.exports = {
    index: (req, res) => {
        Product.find().then(products => {
            res.render('product/index', {
                'products': products
            });
        }).catch(err => {
            res.render('product/index', {error: err.message})
        });
    },
    createGet: (req, res) => {
        res.render('product/create');
    },
    createPost: (req, res) => {
        const productArgs = req.body;
        let errorMsg = '';
        if (!productArgs.priority||productArgs.priority==0) {
            errorMsg = 'Invalid priority! Please fill correct priority!';
        } else if (!productArgs.name) {
            errorMsg = 'Invalid name! Please fill correct name!';
        } else if (!productArgs.quantity||productArgs.quantity==0) {
            errorMsg = 'Invalid quantity! Please fill quantity!';
        }
        else if (!productArgs.status) {
            errorMsg = 'Invalid status! Please fill status!';
        }
        if (errorMsg) {
            res.render('product/create', {error: errorMsg});
            return;
        }
        Product.create(productArgs).then(product => {
            res.redirect('/');
        }).catch(err => {
            productArgs.error = 'Can not create product! Invalid product! Please full fill the form!';
            res.render('product/create', productArgs);
        });
    },
    editGet: (req, res) => {
        let id = req.params.id;
        Product.findById(id).then(product => {
            if (!product) {
                res.redirect('/');
                return;
            }
            res.render('product/edit', product);
        }).catch(err => {
            return res.redirect('/')
        });
    },
    editPost: (req, res) => {
        let id = req.params.id;
        let product = req.body;
        Product.findByIdAndUpdate(id, product, {runValidators: true}).then(products => {
            res.redirect('/');
        }).catch(err => {
            product.id = id;
            product.error = 'Can not edit such product! Invalid product!';
            return res.render('product/edit', product);
        });
    }
};