import 'package:flutter/material.dart';
import 'widgets/todo_item.dart';

void main() {
  runApp(const Main());
}

class Main extends StatelessWidget {
  const Main({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Todo app',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: const HomePage(title: 'Todo app'),
    );
  }
}

class HomePage extends StatefulWidget {
  const HomePage({Key? key, required this.title}) : super(key: key);
  final String title;

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final List<String> _todoItems = ["Item 1", "Item 2", "Item 3"];

  void _addNewTodoItem() {
    //
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: _todoItems.map((todoItem) => TodoItem(text: todoItem)).toList(),
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: _addNewTodoItem,
        tooltip: 'Add new todo item',
        child: const Icon(Icons.add),
      ),
    );
  }
}
