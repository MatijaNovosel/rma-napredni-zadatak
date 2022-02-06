import 'package:dio/dio.dart';
import 'package:rma_napredni_zadatak/models/todo_item.dart';

Future<List<TodoItem>> getTodoItems() async {
  var dio = Dio();
  List<TodoItem> data = [];
  const url = "https://rma-api20220206133123.azurewebsites.net/";

  try {
    var response = await dio.get(url);

    for (var item in response.data) {
      data.add(
        TodoItem(
          text: item["text"],
          id: item["id"],
          done: item["done"],
          createdAt: DateTime.parse(item["createdAt"]),
        ),
      );
    }

    return data;
  } catch (e) {
    print(e);
  } finally {
    dio.close();
  }

  return data;
}

Future addTodoItem(String text) async {
  var dio = Dio();
  const url = "https://rma-api20220206133123.azurewebsites.net/";

  try {
    await dio.post(
      url,
      data: {
        "text": text,
      },
    );
  } catch (e) {
    print(e);
  } finally {
    dio.close();
  }
}

Future markAsDone(int id) async {
  var dio = Dio();
  const url = "https://rma-api20220206133123.azurewebsites.net/";

  try {
    await dio.post(
      "$url/mark-as-done/$id",
    );
  } catch (e) {
    print(e);
  } finally {
    dio.close();
  }
}
