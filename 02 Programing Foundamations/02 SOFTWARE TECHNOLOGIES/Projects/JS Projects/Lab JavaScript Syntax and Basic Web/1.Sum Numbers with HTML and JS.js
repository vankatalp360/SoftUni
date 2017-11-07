 function sumNumbers() {

     let num1 = Number(document.getElementById('num1').value);
     let num2 = Number(document.getElementById('num2').value);
     let sum = num1 + num2;
     let result = document.getElementById("result");
     result.innerHTML = sum;
     result.setAttribute("style", "color:red")

 }