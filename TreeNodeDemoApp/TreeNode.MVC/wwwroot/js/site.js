// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//https://stackoverflow.com/questions/43114404/how-to-serialize-tree-structure-data-from-database-to-json



//https://ole.michelsen.dk/blog/mapping-relational-table-data-to-a-tree-structure-in-mvc/
//https://stackoverflow.com/questions/54169127/how-to-make-html-tree-list-using-knockout
//https://embed.plnkr.co/plunk/qutvxW
//https://rniemeyer.github.io/knockout-kendo/web/TreeView.html

<script>
    $(function () {


        function TreeNode(values) {
            var self = this;
            ko.mapping.fromJS(values, { children: { create: createNode } }, this);
            this.parent = null;
            this.expanded = ko.observable(false);
            this.show = ko.observable(true);
            this.highlight = ko.observable(false);

            this.collapsed = ko.computed(function () {
                return !self.expanded();
            })
        }

        TreeNode.prototype.toggle = function () {
            this.expanded(!this.expanded());
        };

        function createNode(options) {
            return new TreeNode(options.data);
        }

        var root = new TreeNode({
            id: "1", name: "Root", children: [
                {
                    id: "1.1", name: "First 1", children: [
                        {
                            id: "1.1.1", name: "Node 1.1", children: [
                                { id: "1.1.1", name: "Kid 1.1.1", children: [] },
                                { id: "1.1.2", name: "Kid 1.1.2", children: [] }
                            ]
                        },
                        { id: "1.1.2", name: "Next 1.2", children: [] }
                    ]
                },
                {
                    id: "1.2", name: "Second 2", children: [{
                        id: "1.1.1", name: "Third 2.1", children: [
                            { id: "1.1.1", name: "Beta 2.1.1", children: [] },
                            { id: "1.1.2", name: "Zeta 2.1.2", children: [] }
                        ]
                    }]
                }
            ]
        });

        var viewModel = {
            root: root,
            selected: ko.observable(),
            searchterm: ko.observable().extend({ throttle: 400 }),
            searching: ko.observable(false)
        };

        (function hackParents(n) {
            var addParent = function (p) {
                p.children().forEach(function (c) {
                    c.parent = p;
                    addParent(c);
                });
            };
            n.children().forEach(function (child) {
                child.parent = n;
                addParent(child);
            });
        })(viewModel.root);

        console.dir(viewModel.root.children());

        var treeSearch = ko.computed(function () {

            var tree = viewModel.root,
                term = viewModel.searchterm(),
                matchtype = "";//^" //startWith;

            var up = function (n, text, leafMatched) {
                if (!n) { return; } // stop
                n.show(true);
                console.log('showing ' + n.name())
                if (n.parent) {
                    up(n.parent);
                }
            };

            var down = function (n, text) {
                var found;
                found = (new RegExp(matchtype + text, "ig").exec(n.name().trim(), "ig") instanceof Array)
                console.log(n.name(), found, text, n.parent);
                if (n.parent) {
                    n.highlight(found);
                    n.show(found);
                    if (found) {
                        up(n.parent);
                    }
                }
                if (n.children().length) n.expanded(true); //only if has children 

                n.children().forEach(function (child) {
                    down(child, text);
                });

                viewModel.searching(false);
            };

            var resetT = function (n) {
                n.children().forEach(function (child) {
                    resetT(child);
                });
                n.show(true);
                n.highlight(false);
            };

            if (term) {
                viewModel.searching(true);
                resetT(tree);
                down(tree, term);
            } else {
                resetT(tree);
            }

        }).extend({ throttle: 400 });

        ko.applyBindings(viewModel, $('html')[0]);

    });
       
</script>