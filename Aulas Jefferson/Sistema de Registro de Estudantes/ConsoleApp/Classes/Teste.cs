using System;
using System.Runtime.CompilerServices;

class Pilha
{
    private List<object> pilha = new List<object>();

    public void Push(object obj) // Adicionar um novo elemento à pilha, colocando-o no topo.
    {
        pilha.Add(obj);
    }

    public void Pop()
    {
        pilha.RemoveAt(pilha.Count - 1); // Remover o elemento mais recentemente adicionado à pilha, que está no topo.
    }

    public object Peek() // Visualizar o elemento mais recentemente adicionado à pilha, sem removê-lo.
    {
        return pilha[pilha.Count - 1]; 
    }

    public bool IsEmpty() // Verificar se a pilha está vazia.
    {
        if (pilha.Count == 0){
            return true;
        }
        return false;
    }

    public int Size() // Obter o número de elementos na pilha.
    {
        return pilha.Count;
    }
}

class Fila
{
    private List<object> fila = new List<object>();

    public void Enqueue(object obj) // Adicionar um novo elemento à fila, colocando-o no final.
    {
        fila.Add(obj); 
    } 

    public object Dequeue() // Remover e retornar o primeiro elemento da fila.
    {
        object temp = fila[0];
        fila.RemoveAt(0);
        return temp;
    }

    public object Peek() // Visualizar o primeiro elemento da fila, sem removê-lo.
    {
        return fila[0];
    }

    public bool IsEmpty() // Verificar se a fila está vazia.
    {
        if (fila.Count == 0){
            return true;
        }
        return false;
    }

    public int Size() // Obter o número de elementos na fila.
    {
        return fila.Count;
    }
}