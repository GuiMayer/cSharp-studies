using System;
using System.Runtime.CompilerServices;

class Stack
{
    private List<object> stack = new List<object>();

    public void Push(object obj) // Adicionar um novo elemento à pilha, colocando-o no topo.
    {
        stack.Add(obj);
    }

    public void Pop()
    {
        stack.RemoveAt(stack.Count - 1); // Remover o elemento mais recentemente adicionado à pilha, que está no topo.
    }

    public object Peek() // Visualizar o elemento mais recentemente adicionado à pilha, sem removê-lo.
    {
        return stack[stack.Count - 1]; 
    }

    public bool IsEmpty() // Verificar se a pilha está vazia.
    {
        if (stack.Count == 0){
            return true;
        }
        return false;
    }

    public int Size() // Obter o número de elementos na pilha.
    {
        return stack.Count;
    }
}

class Queue
{
    private List<object> queue = new List<object>();

    public void Enqueue(object obj) // Adicionar um novo elemento à fila, colocando-o no final.
    {
        queue.Add(obj); 
    } 

    public object Dequeue() // Remover e retornar o primeiro elemento da fila.
    {
        object temp = queue[0];
        queue.RemoveAt(0);
        return temp;
    }

    public object Peek() // Visualizar o primeiro elemento da fila, sem removê-lo.
    {
        return queue[0];
    }

    public bool IsEmpty() // Verificar se a fila está vazia.
    {
        if (queue.Count == 0){
            return true;
        }
        return false;
    }

    public int Size() // Obter o número de elementos na fila.
    {
        return queue.Count;
    }
}