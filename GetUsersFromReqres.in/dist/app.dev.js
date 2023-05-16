"use strict";

var getAllUsers = function getAllUsers() {
  var response, users, usersdata;
  return regeneratorRuntime.async(function getAllUsers$(_context) {
    while (1) {
      switch (_context.prev = _context.next) {
        case 0:
          _context.next = 2;
          return regeneratorRuntime.awrap(fetch("https://reqres.in/api/users"));

        case 2:
          response = _context.sent;
          _context.next = 5;
          return regeneratorRuntime.awrap(response.json());

        case 5:
          users = _context.sent;
          usersdata = users.data;
          setUsers(usersdata);

        case 8:
        case "end":
          return _context.stop();
      }
    }
  });
};

var setUsers = function setUsers(usersdata) {
  var usersDiv = document.getElementById("users-div");
  usersdata.forEach(function (usersdata) {
    usersDiv.innerHTML += "\n         <div class=\"card col-3 ms-5 p-3 m-2\">\n          <p> ".concat(usersdata.first_name, "</p>\n          <p>").concat(usersdata.email, "</p>\n          <img key=").concat(usersdata.avatar, " src=").concat(usersdata.avatar, " />\n        <a href=\"#\" class=\"btn btn-primary\">Detay</a>\n          \n        ");
  });
};

getAllUsers();