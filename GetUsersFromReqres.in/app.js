const getAllUsers = async()=>{
    const response = await fetch("https://reqres.in/api/users");
    const users = await response.json();
    const usersdata = users.data;
    setUsers(usersdata);
}
const setUsers= (usersdata)=>{
    const usersDiv = document.getElementById("users-div");
    usersdata.forEach(usersdata => {
        usersDiv.innerHTML += `
         <div class="card col-3 ms-5 p-3 m-2">
          <p> ${usersdata.first_name}</p>
          <p>${usersdata.email}</p>
          <img key=${usersdata.avatar} src=${usersdata.avatar} />
          <button class="btn btn-primary mt-2" onclick="myFunction(${usersdata.id})">Detay</button>
        </div>
          
        `;        
    });
}

getAllUsers();
const myFunction = async (id)=> {
    console.log(id);
    const a = await fetch(`https://reqres.in/api/users/${id}`);
    const user = await a.json();
    console.log(user);    
}

