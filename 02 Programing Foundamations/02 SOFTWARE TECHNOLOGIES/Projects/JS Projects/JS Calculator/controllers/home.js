const Calculator = require('../models/Calculator');

module.exports = {
    indexGet: (req, res) => {
        res.render('home/index');
    },
    indexPost: (req, res) => {
        let calculatorParameters = req.body['calculator'];
        let calculator = new Calculator();
        calculator.leftOperand=Number(calculatorParameters.leftOperand);
        calculator.operator = calculatorParameters.operator;
        calculator.rightOperand = Number(calculatorParameters.rightOperand);
        let result  = calculator.calculateResult();
        res.render('home/index',{'calculator':calculator, 'result':result});
    }
};