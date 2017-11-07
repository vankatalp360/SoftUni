function generateAdvertisementMessage(input) {
    let number = parseInt(input);
    let phraces =["Excellent product.",
        "Such a great product.",
        "I always use that product.",
        "Best product of its category.",
        "Exceptional product.",
        "I can’t live without this product."];
    let events  =["Now I feel good.",
        "I have succeeded with this product.",
        "Makes miracles. I am happy of the results!",
        "I cannot believe but now I feel awesome.",
        "Try it yourself, I am very satisfied.",
        "I feel great!"];
    let author = ["Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"];

    let cities = ["Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"];

    for (let i = 1 ; i <=number;i++)
    {
        let phracesIndex = getRandomArbitrary(0,phraces.length);
        let eventsIndex = getRandomArbitrary(0,events.length);
        let authorIndex = getRandomArbitrary(0,author.length);
        let citiesIndex = getRandomArbitrary(0,cities.length);
        console.log(phraces[phracesIndex]+" "+events[eventsIndex]+" "+author[authorIndex]+" - "+cities[citiesIndex]);
    }
    function getRandomArbitrary(min, max) {
        return Math.floor(Math.random() * (max - min) + min);
    }

}

let text = [ '4'];

generateAdvertisementMessage(text);