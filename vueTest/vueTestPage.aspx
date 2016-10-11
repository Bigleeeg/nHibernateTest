<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vueTestPage.aspx.cs" Inherits="vueTest.vueTestPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="scripts/jquery-1.10.2.js"></script>
    <script src="scripts/vue.js"></script>

    <style>
        div {
            margin-top: 20px;
            margin-bottom: 20px;
        }

        ul {
            padding-left: 0;
            font-family: Helvetica, Arial, sans-serif;
        }

        .staggered-transition {
            transition: all .5s ease;
            overflow: hidden;
            margin: 0;
            height: 20px;
        }

        .staggered-enter, .staggered-leave {
            opacity: 0;
            height: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div id="app">
            {{message}}
        </div>
        <hr />

        <div id="app2">
            <p>{{message|capitalize}}</p>
            <input v-model="message" />
        </div>
        <hr />

        <div id="app3">
            <ul>
                <li v-for="todo in todos">{{todo.text}}
                </li>
            </ul>
        </div>
        <hr />

        <div id="app4">
            <p>{{message}}</p>
            <button type="button" v-on:click="reverseMessage">Reverse Message</button>
        </div>
        <hr />

        <div id="app5">
            <input v-model="newTodo" v-on:keyup.enter="addTodo" />
            <ul>
                <li v-for="todo in todos">
                    <span>{{todo.text}}</span>
                    <button type="button" v-on:click="removeTodo($index)">X</button>
                </li>
            </ul>
        </div>
        <hr />

        <div id="app6">
            <p v-if="greeting">Hello Vue.js!</p>
        </div>
        <hr />

        <div id="app7">
            a={{a}},b={{b}}
        </div>
        <hr />

        <div id="app8">
            <p>FullName: {{fullName}}</p>
            <br />
            FirstName:
            <input v-model="firstName" />
            <br />
            <br />
            LastName: 
            <input v-model="lastName" />
        </div>
        <hr />

        <div>
            <ul id="app9">
                <li v-for="item in items">{{parentMessage}}-{{$index}}-{{item.message}}
                </li>
            </ul>
        </div>
        <hr />

        <div>
            <span v-for="n in 10">{{n}}</span>
        </div>
        <hr />

        <div id="app10">
            <button type="button" v-on:click="greet">Greet</button>
        </div>
        <hr />

        <div id="app11">
            <button type="button" v-on:click="say('hi')">Say Hi</button>
            <button type="button" v-on:click="say('what')">Say What</button>
        </div>
        <hr />

        <div id="app12">
            <button type="button" v-on:click="say($event)" id="btn12">Submit</button>
        </div>
        <hr />

        <div id="app13">
            <input v-model="message" v-on:keyup.esc="click" />
        </div>
        <hr />

        <div id="app14">
            <input type="checkbox" id="chk" v-model="checked" />
            <label for="chk">{{ checked }}</label>
        </div>
        <hr />

        <div id="app15">
            <input type="checkbox" id="jack" value="Jack" v-model="checkedNames" />
            <label for="jack">Jack</label>
            <input type="checkbox" id="john" value="John" v-model="checkedNames" />
            <label for="john">John</label>
            <input type="checkbox" id="mike" value="Mike" v-model="checkedNames" />
            <label for="mike">Mike</label>
            <br />
            <span>Checked names: {{ checkedNames | json }}</span>
        </div>
        <hr /> 

    </form>
</body>
</html>

<script>
    var exampleData = {
        message: "Vue.js"
    }

    var vm = new Vue({
        el: "#app",
        data: exampleData,
        created: function () {
            console.log('Message is: ' + this.message);
        }
    });

    new Vue({
        el: "#app2",
        data: {
            message: "Hello Vue.js!"
        }
    });

    Vue.filter('capitalize', function (value) {
        return value.toUpperCase();
    })

    new Vue({
        el: "#app3",
        data: {
            todos: [
                { text: "Learn JavaScript" },
                { text: "Learn Vue.js" },
                { text: "Build Something Awesome" }
            ]
        }
    });

    new Vue({
        el: "#app4",
        data: {
            message: "Hello Vue.js!"
        },
        methods: {
            reverseMessage: function () {
                this.message = this.message.split('').reverse().join('')
            }
        }
    });

    new Vue({
        el: "#app5",
        data: {
            newTodo: "",
            todos: [
                { text: "Add some todos" }
            ]
        },
        methods: {
            addTodo: function () {
                var text = this.newTodo.trim();
                if (text) {
                    this.todos.push({ text: text });
                    this.newTodo = "";
                }
            },
            removeTodo: function (index) {
                this.todos.splice(index, 1);
            }
        }
    });

    new Vue({
        el: "#app6",
        data: {
            greeting: true
        }
    });

    new Vue({
        el: "#app7",
        data: {
            a: 1
        },
        computed: {
            b: function () {
                return this.a + 1;
            }
        }
    });

    //var vmapp8 = new Vue({
    //    el: "#app8",
    //    data: {
    //        firstName: "Foo",
    //        lastName: "Bar",
    //        fullName: "Foo Bar"
    //    }
    //});

    //vmapp8.$watch("firstName", function (val) {
    //    this.fullName = val + ' ' + this.lastName;
    //});

    //vmapp8.$watch("lastName", function (val) {
    //    this.fullName = this.firstName + ' ' + val;
    //});

    //var vmapp8 = new Vue({
    //    el: "#app8",
    //    data: {
    //        firstName: "Foo",
    //        lastName: "Bar"
    //    },
    //    computed: {
    //        fullName: {
    //            get: function () {
    //                return this.firstName + ' ' + this.lastName;
    //            },
    //            set: function (newValue) {
    //                var names = newValue.split(' ');
    //                this.firstName = names[0];
    //                this.lastName = names[names.length - 1]
    //            }
    //        } 
    //    } 
    //});

    var vmapp8 = new Vue({
        el: "#app8",
        data: {
            firstName: "Foo",
            lastName: "Bar"
        },
        computed: {
            fullName: function () {
                return this.firstName + ' ' + this.lastName;
            }
        }
    })

    var vmapp9 = new Vue({
        el: "#app9",
        data: {
            parentMessage: "Parent",
            items: [
                { message: "Foo" },
                { message: "Bar" }
            ]
        }
    });

    var vmapp10 = new Vue({
        el: "#app10",
        data: {
            name: "Vue.js"
        },
        methods: {
            greet: function (button) {
                alert("Hello " + this.name + "!");
                alert(event.target.tagName);
            }
        }
    });

    //vmapp10.greet();

    var vmapp11 = new Vue({
        el: "#app11",
        methods: {
            say: function (msg) {
                alert(msg);
            }
        }
    });

    var vmapp12 = new Vue({
        el: "#app12",
        methods: {
            say: function (event) {
                event.preventDefault();
            }
        }
    });

    var vmapp13 = new Vue({
        el: "#app13",
        data: {
            message: "Vue.js!"
        },
        methods: {
            click: function () {
                this.message = "xxxxxxxx";
            }
        }
    });

    var vmapp14 = new Vue({
        el: "#app14",
        data: {
            checked: false
        }
    });

    var vmapp15 = new Vue({
        el: "#app15",
        data: {
            checkedNames: []
        }
    }); 

</script>
