[En Español](#en-español) | [In English](#in-english) [](#top)

---
<!-- **<span id="en-español" span style="font-size: larger;">Ejemplo: jerarquía de identificadores </span>** -->

<a id="en-español"></a>
**<span style="font-size: larger;">🔗 [Cuestionario simple](#en-español) [🔼](#top)</span>**

**Ejemplo: cuestionario simple**
Como ejemplo de un árbol binario, se utilizará una aplicación de cuestionario simple. El cuestionario consta de algunas preguntas y respuestas, que se muestran según las decisiones tomadas previamente. La aplicación presenta la pregunta, espera a que el usuario presione Y (sí) o N (no) y pasa a la siguiente pregunta o muestra la respuesta.

La estructura del cuestionario se crea en forma de un árbol binario, de la siguiente manera:

Al principio, se le pregunta al usuario si tiene experiencia en el desarrollo de aplicaciones. Si es así, el programa pregunta si ha trabajado como desarrollador durante más de cinco años. En caso de una respuesta positiva, se presenta el resultado sobre la solicitud de trabajar como desarrollador senior. Por supuesto, se muestran otras respuestas y preguntas en caso de decisiones diferentes tomadas por el usuario.

La implementación del cuestionario simple requiere las clases BinaryTree y BinaryTreeNode, que se presentaron y explicaron anteriormente. Además de ellas, debes declarar la clase QuizItem para representar un elemento individual, como una pregunta o una respuesta. Cada elemento contiene solo el contenido textual, almacenado como un valor de la propiedad Text. La implementación adecuada es la siguiente:

```c#
public class QuizItem 
{ 
    public string Text { get; set; } 
    public QuizItem(string text) => Text = text; 
}
```
Se requieren algunas modificaciones en la clase Program. Veamos el método Main modificado:

```c#
static void Main(string[] args) 
{ 
    BinaryTree<QuizItem> tree = GetTree(); 
    BinaryTreeNode<QuizItem> node = tree.Root; 
    while (node != null) 
    { 
        if (node.Left != null || node.Right != null) 
        { 
            Console.Write(node.Data.Text); 
            switch (Console.ReadKey(true).Key) 
            { 
                case ConsoleKey.Y: 
                    WriteAnswer(" Sí"); 
                    node = node.Left; 
                    break; 
                case ConsoleKey.N: 
                    WriteAnswer(" No"); 
                    node = node.Right; 
                    break; 
            } 
        } 
        else 
        { 
            WriteAnswer(node.Data.Text); 
            node = null; 
        } 
    } 
}
```
En la primera línea dentro del método, se llama al método GetTree (mostrado en el siguiente fragmento de código) para construir el árbol con preguntas y respuestas. Luego, se toma el nodo raíz como el nodo actual, para el cual se realizan las siguientes operaciones hasta llegar a la respuesta.

Al principio, se verifica si el nodo hijo izquierdo o derecho existe, es decir, si es una pregunta (no una respuesta). Luego, se escribe el contenido textual en la consola y el programa espera hasta que el usuario presione una tecla. Si es igual a Y, se muestra la información sobre la elección de la opción sí y se utiliza el hijo izquierdo del nodo actual como el nodo actual. Se realizan operaciones similares en el caso de elegir no, pero en ese caso, en lugar del hijo derecho del nodo actual.

Cuando las decisiones tomadas por el usuario hacen que se muestre la respuesta, esta se presenta en la consola y se asigna null a la variable del nodo. Por lo tanto, se sale del bucle while.

Como se mencionó, el método GetTree se utiliza para construir el árbol binario con preguntas y respuestas. Su código se presenta de la siguiente manera:

```c#
private static BinaryTree<QuizItem> GetTree() 
{ 
    BinaryTree<QuizItem> tree = new BinaryTree<QuizItem>(); 
    tree.Root = new BinaryTreeNode<QuizItem>() 
    { 
        Data = new QuizItem("¿Tiene experiencia en el desarrollo de aplicaciones?"), 
        Children = new List<TreeNode<QuizItem>>() 
        { 
            new BinaryTreeNode<QuizItem>() 
            { 
                Data = new QuizItem("¿Ha trabajado como desarrollador durante más de 5 años?"), 
                Children = new List<TreeNode<QuizItem>>() 
                { 
                    new BinaryTreeNode<QuizItem>() 
                    { 
                        Data = new QuizItem("¡Solicite como desarrollador senior!") 
                    }, 
                    new BinaryTreeNode<QuizItem>() 
                    { 
                        Data = new QuizItem("¡Solicite como desarrollador intermedio!") 
                    } 
                } 
            }, 
            new BinaryTreeNode<QuizItem>() 
            { 
                Data = new QuizItem("¿Ha completado la universidad?"), 
                Children = new List<TreeNode<QuizItem>>() 
                { 
                    new BinaryTreeNode<QuizItem>() 
                    { 
                        Data = new QuizItem("¡Solicite como desarrollador junior!") 
                    }, 
                    new BinaryTreeNode<QuizItem>() 
                    { 
                        Data = new QuizItem("¿Tendrá tiempo durante el semestre?"), 
                        Children = new List<TreeNode<QuizItem>>() 
                        { 
                            new BinaryTreeNode<QuizItem>() 
                            { 
                                Data = new QuizItem("¡Solicite en nuestro programa de pasantías a largo plazo!") 
                            }, 
                            new BinaryTreeNode<QuizItem>() 
                            { 
                                Data = new QuizItem("¡Solicite en nuestro programa de pasantías de verano!") 
                            } 
                        } 
                    } 
                } 
            } 
        } 
    }; 
    tree.Count = 9; 
    return tree; 
}
```
Al principio, se crea una nueva instancia de la clase genérica BinaryTree. También se configura para que cada nodo contenga datos como una instancia de la clase QuizItem. Luego, asignas una nueva instancia de BinaryTreeNode a la propiedad Root.

Lo interesante es que incluso al crear preguntas y respuestas programáticamente, creas una especie de estructura similar a un árbol, porque utilizas la propiedad Children y especificas elementos directamente dentro de tales construcciones. Por lo tanto, no necesitas crear muchas variables locales para todas las preguntas y respuestas. Es importante señalar que un nodo relacionado con una pregunta es una instancia de la clase BinaryTreeNode con dos nodos secundarios (para decisiones sí y no), mientras que un nodo relacionado con una respuesta no puede contener ningún nodo secundario.

En la solución presentada, los valores de la propiedad Parent de las instancias de BinaryTreeNode no están configurados. Si deseas utilizarlos o conocer la altura de un nodo o un árbol, debes configurarlos por tu cuenta.

El último método auxiliar es WriteAnswer, con el código de la siguiente manera:

```c#
private static void WriteAnswer(string text) 
{ 
    Console.ForegroundColor = ConsoleColor.White; 
    Console.WriteLine(text); 
    Console.ForegroundColor = ConsoleColor.Gray; 
}
```
El método simplemente presenta el texto, pasado como parámetro, en color blanco en la consola. Se utiliza para mostrar las decisiones tomadas por el usuario y el contenido textual de la respuesta.

¡La aplicación de cuestionario simple está lista! Puedes construir el proyecto, ejecutarlo y responder algunas preguntas para ver los resultados. Luego, cierre el programa y continúe con la siguiente sección, donde se presenta una variante de la estructura de datos del árbol binario.
------------------------------------
<!-- <a id="in-english"></a>
**<span id="in-english" span style="font-size: larger;">Example – hierarchy of identifiers(#in-english)</span>** -->

<a id="in-english"></a>
**<span style="font-size: larger;">🔗 [Simple Quiz](#in-english) [🔼](#top)</span>**

**Example – simple quiz**
As an example of a binary tree, a simple quiz application will be used. The quiz consists of a few questions and answers, shown depending on the previously-taken decisions. The application presents the question, waits until the user presses Y (yes) or N (no), and proceeds to the next question or shows the answer.

The structure of the quiz is created in the form of a binary tree, as follows:


At the beginning, the user is asked whether he or she has any experience in application development. If so, the program asks whether he or she has worked as a developer for more than five years. In the case of a positive answer, the result regarding applying to work as a senior developer is presented. Of course, other answers and questions are shown in the case of different decisions taken by the user.

The implementation of the simple quiz requires the BinaryTree and BinaryTreeNode classes, which were presented and explained earlier. Apart from them, you should declare the QuizItem class to represent a single item, such as a question or an answer. Each item contains only the textual content, stored as a value of the Text property. The proper implementation is as follows:
```c#
public class QuizItem 
{ 
    public string Text { get; set; } 
    public QuizItem(string text) => Text = text; 
}
```
Some modifications are necessary in the Program class. Let's take a look at the modified Main method:
```c#
static void Main(string[] args) 
{ 
    BinaryTree<QuizItem> tree = GetTree(); 
    BinaryTreeNode<QuizItem> node = tree.Root; 
    while (node != null) 
    { 
        if (node.Left != null || node.Right != null) 
        { 
            Console.Write(node.Data.Text); 
            switch (Console.ReadKey(true).Key) 
            { 
                case ConsoleKey.Y: 
                    WriteAnswer(" Yes"); 
                    node = node.Left; 
                    break; 
                case ConsoleKey.N: 
                    WriteAnswer(" No"); 
                    node = node.Right; 
                    break; 
            } 
        } 
        else 
        { 
            WriteAnswer(node.Data.Text); 
            node = null; 
        } 
    } 
}
```
In the first line within the method, the GetTree method (shown in the following code snippet) is called to construct the tree with questions and answers. Then, the root node is taken as the current node, for which the following operations are taken until the answer is reached.

At the beginning, you check whether the left or right child node exists, that is, whether it is a question (not an answer). Then, the textual content is written in the console and the program waits until the user presses a key. If it is equal to Y, the information about choosing the yes option is shown and the current node's left child is used as the current node. Similar operations are performed in the case of choosing no, but then the current node's right child is used instead.

When decisions taken by the user cause the answer to be shown, it is presented in the console and null is assigned to the node variable. Therefore, you break out of the while loop.

As mentioned, the GetTree method is used to construct the binary tree with questions and answers. Its code is presented as follows:
```c#
private static BinaryTree<QuizItem> GetTree() 
{ 
    BinaryTree<QuizItem> tree = new BinaryTree<QuizItem>(); 
    tree.Root = new BinaryTreeNode<QuizItem>() 
    { 
        Data = new QuizItem("Do you have experience in developing  
            applications?"), 
        Children = new List<TreeNode<QuizItem>>() 
        { 
            new BinaryTreeNode<QuizItem>() 
            { 
                Data = new QuizItem("Have you worked as a  
                    developer for more than 5 years?"), 
                Children = new List<TreeNode<QuizItem>>() 
                { 
                    new BinaryTreeNode<QuizItem>() 
                    { 
                        Data = new QuizItem("Apply as a senior  
                            developer!") 
                    }, 
                    new BinaryTreeNode<QuizItem>() 
                    { 
                        Data = new QuizItem("Apply as a middle  
                            developer!") 
                    } 
                } 
            }, 
            new BinaryTreeNode<QuizItem>() 
            { 
                Data = new QuizItem("Have you completed  
                    the university?"), 
                Children = new List<TreeNode<QuizItem>>() 
                { 
                    new BinaryTreeNode<QuizItem>() 
                    { 
                        Data = new QuizItem("Apply for a junior  
                            developer!") 
                    }, 
                    new BinaryTreeNode<QuizItem>() 
                    { 
                        Data = new QuizItem("Will you find some  
                            time during the semester?"), 
                        Children = new List<TreeNode<QuizItem>>() 
                        { 
                            new BinaryTreeNode<QuizItem>() 
                            { 
                                Data = new QuizItem("Apply for our  
                                   long-time internship program!") 
                            }, 
                            new BinaryTreeNode<QuizItem>() 
                            { 
                                Data = new QuizItem("Apply for  
                                   summer internship program!") 
                            } 
                        } 
                    } 
                } 
            } 
        } 
    }; 
    tree.Count = 9; 
    return tree; 
}
```
At the beginning, a new instance of the BinaryTree generic class is created. It is also configured that each node contains data as an instance of the QuizItem class. Then, you assign a new instance of the BinaryTreeNode to the Root property.

What is interesting is that even while creating questions and answers programmatically, you create some kind of tree-like structure, because you use the Children property and specify items directly within such constructions. Therefore, you do not need to create many local variables for all questions and answers. It is worth noting that a question-related node is an instance of the BinaryTreeNode class with two child nodes (for  yes and no decisions), while an answer-related node cannot contain any child nodes.

In the presented solution, the values of the Parent property of the BinaryTreeNode instances are not set. If you want to use them or get the height of a node or a tree, you should set them on your own.
The last auxiliary method is WriteAnswer, with the code being as follows:
```c#
private static void WriteAnswer(string text) 
{ 
    Console.ForegroundColor = ConsoleColor.White; 
    Console.WriteLine(text); 
    Console.ForegroundColor = ConsoleColor.Gray; 
}
```
The method just presents the text, passed as the parameter, in the white color in the console. It is used to show decisions taken by the user and the textual content of the answer.

The simple quiz application is ready! You can build the project, launch it, and answer a few questions to see the results. Then, let's close the program and proceed to the next section, where a variant of the binary tree data structure is presented.