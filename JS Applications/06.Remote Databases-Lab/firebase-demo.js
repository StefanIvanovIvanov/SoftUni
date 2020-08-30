const firebaseConfig = {
apiKey: "api-key",
authDomain: "project-id.firebaseapp.com",
databaseURL: "https://project-id.firebaseio.com",
projectID: "project-id",
storageBucket: "project-id.appspot.com",
messagingSenderId: "sender-id",
appID: "app-id",
measurementID: "G-measurement-id"
}

firebase.initializeApp(firebaseConfig);


firebase.auth().createUserWithEmailAndPassword(email, password)
.catch((error) => {
     // Handle Errors here.
     let errorCode = error.code;
     let errorMessage = error.message;
     // ...
});


firebase.auth().signInUserWithEmailAndPassword(email, password)
.catch((error) => {
     // Handle Errors here.
     let errorCode = error.code;
     let errorMessage = error.message;
     // ...
});


firebase.auth().onAuthStateChanged((user) => {
    if (user) {
        // User is signed in.
        let displayName = user.displayName;
        let email = user.email;
        let emailVerified = user.emailVerified;
        let isAnonymous = user.isAnonymous;
        let uid = user.uid;
        // ...
    } else {
        // User is signed out.
        // ...
    }
});