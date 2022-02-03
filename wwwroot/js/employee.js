////const employeelistcreateuserpopupsection = document.querySelector(
////    ".employeelist-adduser-form-section"
////);
////var sidebarStatus = document.querySelector(".main-container-sidebar-btn");
////if (sidebarStatus.classList.contains("sidebarOpen"))
////{
////    employeelistcreateuserpopupsection.classList.remove("showfullwidth");
////}
////else
////{
////   employeelistcreateuserpopupsection.classList.add("showfullwidth");
//// }
//const subcribebtn = document.querySelector('.subcribebtn');
//const videocontainer = document.querySelector('.video-container');
//subcribebtn.addEventListener('click', () => {
//    videocontainer.classList.toggle('show');
//    if (videocontainer.classList.contains("show")) {
//        subcribebtn.style.background = "grey";
//    }
//    else {
//        subcribebtn.style.background = "#007ae1";
//    }
//})
//console.log(subcribebtn)
//console.log(videocontainer)
// const subcribebtn = document.querySelector('.subcribebtn');
// const videocontainer = document.querySelector('.video-container');
// subcribebtn.addEventListener('click',()=>{
//     videocontainer.classList.toggle('show');
//     if(videocontainer.classList.contains("show")){
//         subcribebtn.style.background="grey";
//     }
//     else{
//         subcribebtn.style.background="#007ae1";
//     }
// })
// console.log(subcribebtn)
// console.log(videocontainer)

const subcribebtn = document.querySelector('.subcribebtn');
const videocontainer = document.querySelector('.video-container');
let totalDays;
let getTotalNoOfDays = () => {
    // debugger;
    return (totalDays = localStorage.getItem("class"));
    // return localStorage.getItem("highLighMode");
};

window.addEventListener('load', () => {
    getTotalNoOfDays();

    if (totalDays == "show") {
        videocontainer.classList.add('show');
        subcribebtn.style.background = "grey";

    }
    else if (totalDays == "unshow") {
        videocontainer.classList.remove('show');
        subcribebtn.style.background = "#3f5fbd";


    }
})
subcribebtn.addEventListener('click', (e) => {
    e.preventDefault();
    videocontainer.classList.toggle('show');



    //   if(videocontainer == "show"){
    //     localStorage.setItem("class", show);
    //       videocontainer.classList.add('show');
    //   }
    //   else{
    //     localStorage.setItem("class", "");

    //   }
    if (videocontainer.classList.contains("show")) {

        localStorage.setItem("class", 'show');
        subcribebtn.style.background = "grey";
        // debugger;
    }
    else {
        localStorage.setItem('class', 'unshow');
        subcribebtn.style.background = "#3f5fbd";
    }









})

console.log(totalDays)




let usercommetbtn = document.querySelector('.usercommetbtn');
usercommetbtn.addEventListener('click', (e) => {
    e.preventDefault();
    let usercommet = document.querySelector('.usercommetval').value;

    let allcommetdiv = document.querySelector('.allcommetdiv');


    let createusercommet = document.createElement("div");
    createusercommet.classList = "allusercommet";

    let createcommetuserimg = document.createElement("div");
    createcommetuserimg.classList = "commentuserimage";

    let createeachusercomment = document.createElement("div");
    createeachusercomment.classList = "eachusercomment";

    let createh3 = document.createElement("h3");
    createh3.textContent = `Mananjay Shrestha`
    let createp = document.createElement("p");
    createp.textContent = `${usercommet}`
    let createimg = document.createElement("img");
    createimg.src = `images/profile.jpg`;


    allcommetdiv.appendChild(createusercommet);
    createusercommet.appendChild(createcommetuserimg);
    createusercommet.appendChild(createeachusercomment);
    createcommetuserimg.appendChild(createimg);

    createeachusercomment.appendChild(createh3);
    createeachusercomment.appendChild(createp);

    let usercommettext = document.querySelector('.usercommetval');
    usercommettext.value = null;

})