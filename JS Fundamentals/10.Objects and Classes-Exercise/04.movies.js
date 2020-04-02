function movies(params) {
    let movies = [];

    for (let param of params) {
        if (param.includes("addMovie")) {
            let result = param.split("addMovie ").filter(x => x !== "");
            movies.push({
                name: result.join(" ")
            });
        }
        else if (param.includes(" directedBy ")) {
            let splitted = param.split(" directedBy ").filter(x => x !== "");
            let movie = splitted[0];
            let director = splitted[1];
            let result = movies.find(m => m.name === movie);
            if (result !== undefined) {
                result["director"] = director;
            }

        }
        else if (param.includes(" onDate ")) {
            let splitted = param.split(" onDate ");
            let movie = splitted[0];
            let date = splitted[1];
            let result = movies.find(m => m.name === movie);
            if (result !== undefined) {
                result["date"] = date;
            }
        }
    }
    for (let movie of movies) {
        if (movie.name && movie.director && movie.date) {
            console.log(JSON.stringify(movie));
        }
    }
}

movies(['addMovie Fast and Furious','addMovie Godfather','Inception directedBy Christopher Nolan','Godfather directedBy Francis Ford Coppola', 'Godfather onDate 29.07.2018','Fast and Furious onDate 30.07.2018','Batman onDate 01.08.2018','Fast and Furious directedBy Rob Cohen']);