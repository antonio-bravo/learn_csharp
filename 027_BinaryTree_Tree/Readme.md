[En Español](#en-español) | [In English](#in-english) [](#top)

---
<!-- **<span id="en-español" span style="font-size: larger;">Ejemplo: jerarquía de identificadores </span>** -->

<a id="en-español"></a>
**<span style="font-size: larger;">🔗 [Árbol](#en-español) [🔼](#top)</span>**

**Árbol**
La siguiente clase necesaria se llama BinaryTree (Árbol binario). Representa todo el árbol binario. Al utilizar la clase genérica, puedes especificar fácilmente el tipo de datos almacenado en cada nodo. La primera parte de la implementación de la clase BinaryTree es la siguiente:

```c#
public class BinaryTree<T> 
{ 
    public BinaryTreeNode<T> Root { get; set; } 
    public int Count { get; set; } 
}
```
La clase BinaryTree contiene dos propiedades: Root (Raíz), que indica el nodo raíz (como una instancia de la clase BinaryTreeNode), y Count (Contador), 
que tiene el número total de nodos colocados en el árbol. Por supuesto, estos no son los únicos miembros de la clase, ya que también se puede equipar con un conjunto de métodos relacionados con la travesía del árbol.

El primer método de travesía, descrito en este libro, es el preorden. Como recordatorio, primero visita el nodo actual, luego su hijo izquierdo, seguido por el hijo derecho. El código del método TraversePreOrder es el siguiente:

```c#
private void TraversePreOrder(BinaryTreeNode<T> node,  
    List<BinaryTreeNode<T>> result) 
{ 
    if (node != null) 
    { 
        result.Add(node); 
        TraversePreOrder(node.Left, result); 
        TraversePreOrder(node.Right, result); 
    } 
}
```
El método toma dos parámetros: el nodo actual (node) y la lista de nodos ya visitados (result). La implementación recursiva es muy simple. Primero, verificas si el nodo existe asegurándote de que el parámetro no sea igual a null. Luego, agregas el nodo actual a la colección de nodos visitados, comienzas el mismo método de travesía para el hijo izquierdo y, al final, lo inicias para el hijo derecho.

Una implementación similar es posible para los modos de travesía en orden y postorden. Comencemos con el código del método TraverseInOrder, como se muestra a continuación:

```c#
private void TraverseInOrder(BinaryTreeNode<T> node,  
    List<BinaryTreeNode<T>> result) 
{ 
    if (node != null) 
    { 
        TraverseInOrder(node.Left, result); 
        result.Add(node); 
        TraverseInOrder(node.Right, result); 
    } 
}
```
Aquí, llamas recursivamente al método TraverseInOrder para el hijo izquierdo, agregas el nodo actual a la lista de nodos visitados y comienzas la travesía en orden para el hijo derecho.

El siguiente método está relacionado con el modo de travesía postorden, como se muestra a continuación:

```c#
private void TraversePostOrder(BinaryTreeNode<T> node,  
    List<BinaryTreeNode<T>> result) 
{ 
    if (node != null) 
    { 
        TraversePostOrder(node.Left, result); 
        TraversePostOrder(node.Right, result); 
        result.Add(node); 
    } 
}
```
El código es muy similar a los métodos ya descritos, pero, por supuesto, se aplica otro orden de visita de nodos. Aquí, comienzas con el hijo izquierdo, luego visitas el hijo derecho, seguido por el nodo actual.

Finalmente, agreguemos el método público para recorrer el árbol en varios modos, que llama a los métodos privados presentados anteriormente. El código relevante es el siguiente:

```c#
public List<BinaryTreeNode<T>> Traverse(TraversalEnum mode) 
{ 
    List<BinaryTreeNode<T>> nodes = new List<BinaryTreeNode<T>>(); 
    switch (mode) 
    { 
        case TraversalEnum.PREORDER: 
            TraversePreOrder(Root, nodes); 
            break; 
        case TraversalEnum.INORDER: 
            TraverseInOrder(Root, nodes); 
            break; 
        case TraversalEnum.POSTORDER: 
            TraversePostOrder(Root, nodes); 
            break; 
    } 
    return nodes; 
}
```
El método toma solo un parámetro, un valor de la enumeración TraversalEnum, que elige el modo adecuado entre preorden, en orden y postorden. El método Traverse utiliza la instrucción switch para llamar a un método privado adecuado, según el valor del parámetro.

Para utilizar el método Traverse, también es necesario declarar la enumeración TraversalEnum, como se muestra en el siguiente fragmento de código:

```c#
public enum TraversalEnum 
{ 
    PREORDER, 
    INORDER, 
    POSTORDER 
}
```
El último método descrito en esta sección es GetHeight (Obtener altura). Devuelve la altura del árbol, que se puede entender como el número máximo de pasos para viajar desde cualquier nodo hoja hasta la raíz. La implementación es la siguiente:

```c#
public int GetHeight() 
{ 
    int height = 0; 
    foreach (BinaryTreeNode<T> node  
        in Traverse(TraversalEnum.PREORDER)) 
    { 
        height = Math.Max(height, node.GetHeight()); 
    } 
    return height; 
}
```
El código simplemente itera a través de todos los nodos del árbol utilizando la travesía en preorden, lee la altura para el nodo actual (utilizando el método GetHeight de la clase TreeNode, descrito anteriormente) y la guarda como la máxima, si es mayor que el valor máximo actual. Al final, se devuelve la altura calculada.

Después de la introducción al tema de los árboles binarios, veamos un ejemplo donde esta estructura de datos se utiliza para almacenar preguntas y respuestas en un cuestionario simple.
------------------------------------
<!-- <a id="in-english"></a>
**<span id="in-english" span style="font-size: larger;">Example – hierarchy of identifiers(#in-english)</span>** -->

<a id="in-english"></a>
**<span style="font-size: larger;">🔗 [Tree](#in-english) [🔼](#top)</span>**

**Tree**
The next necessary class is named BinaryTree. It represents the whole binary tree. By using the generic class, you can easily specify a type of data stored in each node. The first part of the implementation of the BinaryTree class is as follows:
```c#
public class BinaryTree<T> 
{ 
    public BinaryTreeNode<T> Root { get; set; } 
    public int Count { get; set; } 
}
```
The BinaryTree class contains two properties: Root, which indicates the root node (as an instance of the BinaryTreeNode class), as well as Count, which has the total number of nodes placed in the tree. Of course, these are not the only members of the class, because it can also be equipped with a set of methods regarding traversing the tree.

The first traversal method, described in this book, is pre-order. As a reminder, it first visits the current node, then its left child, followed by the right child. The code of the TraversePreOrder method is as follows:
```c#
private void TraversePreOrder(BinaryTreeNode<T> node,  
    List<BinaryTreeNode<T>> result) 
{ 
    if (node != null) 
    { 
        result.Add(node); 
        TraversePreOrder(node.Left, result); 
        TraversePreOrder(node.Right, result); 
    } 
}
```
The method takes two parameters: the current node (node) and the list of already-visited nodes (result). The recursive implementation is very simple. First, you check whether the node exists by ensuring that the parameter is not equal to null. Then, you add the current node to the collection of visited nodes, start the same traversal method for the left child, and—at the end—start it for the right child.

Similar implementation is possible for the in-order and post-order traversal modes. Let's start with the code of the TraverseInOrder method, as follows:
```c#
private void TraverseInOrder(BinaryTreeNode<T> node,  
    List<BinaryTreeNode<T>> result) 
{ 
    if (node != null) 
    { 
        TraverseInOrder(node.Left, result); 
        result.Add(node); 
        TraverseInOrder(node.Right, result); 
    } 
}
```
Here, you recursively call the TraverseInOrder method for the left child, add the current node to the list of visited nodes, and start the in-order traversal for the right child.

The next method is related to the post-order traversal mode, as follows:
```c#
private void TraversePostOrder(BinaryTreeNode<T> node,  
    List<BinaryTreeNode<T>> result) 
{ 
    if (node != null) 
    { 
        TraversePostOrder(node.Left, result); 
        TraversePostOrder(node.Right, result); 
        result.Add(node); 
    } 
}
```
The code is very similar to the already-described methods, but, of course, another order of visiting nodes is applied. Here, you start with the left child, then you visit the right child, followed by the current node.

Finally, let's add the public method for traversing the tree in various modes, which calls private methods presented earlier. The relevant code is as follows:
```c#
public List<BinaryTreeNode<T>> Traverse(TraversalEnum mode) 
{ 
    List<BinaryTreeNode<T>> nodes = new List<BinaryTreeNode<T>>(); 
    switch (mode) 
    { 
        case TraversalEnum.PREORDER: 
            TraversePreOrder(Root, nodes); 
            break; 
        case TraversalEnum.INORDER: 
            TraverseInOrder(Root, nodes); 
            break; 
        case TraversalEnum.POSTORDER: 
            TraversePostOrder(Root, nodes); 
            break; 
    } 
    return nodes; 
}
```
The method takes only one parameter, a value of the TraversalEnum enumeration, which chooses the proper mode from pre-order, in-order, and post-order. The Traverse method uses the switch statement to call a suitable private method, depending on a value of the parameter.

For using the Traverse method, it is also necessary to declare the TraversalEnum enumeration, as shown in the following code snippet:
```c#
public enum TraversalEnum 
{ 
    PREORDER, 
    INORDER, 
    POSTORDER 
}
```
The last method described in this section is GetHeight. It returns the height of the tree, which can be understood as the maximum number of steps to travel from any leaf node to the root. The implementation is as follows:
```c#
public int GetHeight() 
{ 
    int height = 0; 
    foreach (BinaryTreeNode<T> node  
        in Traverse(TraversalEnum.PREORDER)) 
    { 
        height = Math.Max(height, node.GetHeight()); 
    } 
    return height; 
}
```
The code just iterates through all nodes of the tree using the pre-order traversal, reads the height for the current node (using the GetHeight method from the TreeNode class, described earlier), and saves it as the maximum one, if it is larger than the current maximum value. At the end, the calculated height is returned.

After the introduction to the topic of binary trees, let's see an example where this data structure is used for storing questions and answers in a simple quiz.