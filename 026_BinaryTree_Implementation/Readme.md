[En Español](#en-español) | [In English](#in-english) [](#top)

---
<!-- **<span id="en-español" span style="font-size: larger;">Ejemplo: jerarquía de identificadores </span>** -->

<a id="en-español"></a>
**<span style="font-size: larger;">🔗 [Nodo](#en-español) [🔼](#top)</span>**

**Nodo**
Un nodo en un árbol binario está representado por una instancia de BinaryTreeNode, que hereda de la clase genérica TreeNode con el siguiente código:

```c#
public class TreeNode<T> 
{ 
    public T Data { get; set; } 
    public TreeNode<T> Parent { get; set; } 
    public List<TreeNode<T>> Children { get; set; } 
 
    public int GetHeight() 
    { 
        int altura = 1; 
        TreeNode<T> actual = this; 
        while (actual.Parent != null) 
        { 
            altura++; 
            actual = actual.Parent; 
        } 
        return altura; 
    } 
}
```
En la clase BinaryTreeNode, es necesario declarar dos propiedades, Left (Izquierda) y Right (Derecha), que representan los dos posibles hijos de un nodo. La parte relevante del código es la siguiente:

```c#
public class BinaryTreeNode<T> : TreeNode<T> 
{ 
    public BinaryTreeNode() => Children =  
        new List<TreeNode<T>>() { null, null }; 
 
    public BinaryTreeNode<T> Izquierda 
    { 
        get { return (BinaryTreeNode<T>)Children[0]; } 
        set { Children[0] = value; } 
    } 
 
    public BinaryTreeNode<T> Derecha 
    { 
        get { return (BinaryTreeNode<T>)Children[1]; } 
        set { Children[1] = value; } 
    } 
}
```
Además, debes asegurarte de que la colección de nodos hijos contenga exactamente dos elementos, inicialmente establecidos como nulos. Puedes lograr este objetivo asignando un valor predeterminado a la propiedad Children en el constructor, como se muestra en el código anterior. De esta manera, si deseas agregar un nodo hijo, una referencia a él debe colocarse como el primer o el segundo elemento de la lista (la propiedad Children). Por lo tanto, esta colección siempre tiene exactamente dos elementos y puedes acceder al primero o al segundo elemento sin excepciones. Si se establece en cualquier nodo, se devuelve una referencia a él; de lo contrario, se devuelve nulo.

------------------------------------
<!-- <a id="in-english"></a>
**<span id="in-english" span style="font-size: larger;">Example – hierarchy of identifiers(#in-english)</span>** -->

<a id="in-english"></a>
**<span style="font-size: larger;">🔗 [Node](#in-english) [🔼](#top)</span>**

**Node**
A node in a binary tree is represented by an instance of BinaryTreeNode, which inherits from the TreeNode generic class with the following code:

```c#
public class TreeNode<T> 
{ 
    public T Data { get; set; } 
    public TreeNode<T> Parent { get; set; } 
    public List<TreeNode<T>> Children { get; set; } 
 
    public int GetHeight() 
    { 
        int height = 1; 
        TreeNode<T> current = this; 
        while (current.Parent != null) 
        { 
            height++; 
            current = current.Parent; 
        } 
        return height; 
    } 
}
```
In the BinaryTreeNode class, it is necessary to declare two properties, Left and Right, which represent both possible children of a node. The relevant part of code is as follows:
```c#
public class BinaryTreeNode<T> : TreeNode<T> 
{ 
    public BinaryTreeNode() => Children =  
        new List<TreeNode<T>>() { null, null }; 
 
    public BinaryTreeNode<T> Left 
    { 
        get { return (BinaryTreeNode<T>)Children[0]; } 
        set { Children[0] = value; } 
    } 
 
    public BinaryTreeNode<T> Right 
    { 
        get { return (BinaryTreeNode<T>)Children[1]; } 
        set { Children[1] = value; } 
    } 
}
```
Moreover, you need to ensure that the collection of child nodes contains exactly two items, initially set to null. You can achieve this goal by assigning a default value to the Children property in the constructor, as shown in the preceding code. Thus, if you want to add a child node, a reference to it should be placed as the first or the second element of the list (the Children property). Therefore, such a collection always has exactly two elements and you can access the first or the second element without any exception. If it is set to any node, a reference to it is returned, otherwise null is returned.