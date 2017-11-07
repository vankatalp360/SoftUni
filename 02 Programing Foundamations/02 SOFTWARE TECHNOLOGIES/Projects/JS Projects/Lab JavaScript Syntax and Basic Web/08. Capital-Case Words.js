function extractCapitalWords (lines) {
    let result = [];
for(let line of lines )
{
    let words = line.split(/[^0-9a-zA-Z]/);
    let allWords = words.filter(e => e.length > 0);
    let allCapitalWords = allWords.filter( e => e===e.toUpperCase());
    for(let word of allCapitalWords)
    {
       result.push(word);
    }
}
    console.log (result.join(', '));
}

let wholeText = [ 'We start by HTML, CSS, JavaScript, JSON and REST.',
    'Later we touch some PHP, MySQL and SQL.',
    'Later we play with C#, EF, SQL Server and ASP.NET MVC.',
    'Finally, we touch some Java, Hibernate and Spring.MVC.' ];
extractCapitalWords(wholeText);
