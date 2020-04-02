function name(band, album, song) {
    let bandChars = band.length;
    let albumChars = album.length;
    let songChars = song.length;

    let songDuration = +(albumChars * bandChars * songChars / 2);
    let rotations = songDuration / 2.5;

    console.log(`The plate was rotated ${Math.ceil(rotations)} times.`);
}

name('Black Sabbath', 'Paranoid', 'War Pigs');