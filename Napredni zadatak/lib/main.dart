import 'package:flutter/material.dart';
import 'package:rma_napredni_zadatak/todo-service.dart';
import 'models/todo_item.dart';
import 'widgets/todo_item.dart';
import 'package:collection/collection.dart';

void main() {
  runApp(const Main());
}

class Main extends StatelessWidget {
  const Main({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      title: 'Todo app',
      debugShowCheckedModeBanner: false,
      home: TodoPage(title: 'Todo app'),
    );
  }
}

class TodoPage extends StatefulWidget {
  final String title;

  const TodoPage({
    Key? key,
    required this.title,
  }) : super(key: key);

  @override
  State<TodoPage> createState() => _TodoPageState();
}

class _TodoPageState extends State<TodoPage> {
  final TextEditingController _textFieldController = TextEditingController();
  Future<List<TodoItem>> _todoItems = getTodoItems();

  void _addNewTodoItem(String text) async {
    await addTodoItem(text);
    setState(() {
      _todoItems = getTodoItems();
    });
  }

  void _markItemAsDone(int id) async {
    await markAsDone(id);
    setState(() {
      _todoItems = getTodoItems();
    });
  }

  Future<dynamic> _displayDialog(BuildContext context) async {
    return showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text('Add a task to your list'),
          content: TextField(
            controller: _textFieldController,
            decoration: const InputDecoration(hintText: 'Enter todo item'),
          ),
          actions: <Widget>[
            TextButton(
              child: const Text('ADD'),
              onPressed: () {
                Navigator.of(context).pop();
                _addNewTodoItem(_textFieldController.text);
                _textFieldController.text = "";
              },
            ),
            TextButton(
              child: const Text('CANCEL'),
              onPressed: () {
                _textFieldController.text = "";
                Navigator.of(context).pop();
              },
            )
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Padding(
        padding: const EdgeInsets.all(8.0),
        child: FutureBuilder(
          future: _todoItems,
          builder: (
            context,
            AsyncSnapshot<List<TodoItem>> snapshot,
          ) {
            switch (snapshot.connectionState) {
              case ConnectionState.waiting:
                {
                  return const Center(
                    child: CircularProgressIndicator(),
                  );
                }
              default:
                {
                  if (snapshot.hasError) {
                    return Text('Error: ${snapshot.error}');
                  } else {
                    List<TodoItem> data = snapshot.data as List<TodoItem>;
                    if (data.isEmpty) {
                      return const Center(
                        child: Text("No todo items found!"),
                      );
                    } else {
                      return ListView.builder(
                        itemCount: data.length,
                        itemBuilder: (context, index) => TodoItemWidget(
                          content: data[index],
                          onMarkAsDone: () => _markItemAsDone(data[index].id),
                        ),
                      );
                    }
                  }
                }
            }
          },
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () => _displayDialog(context),
        tooltip: 'Add new todo item',
        child: const Icon(Icons.add),
      ),
    );
  }
}
