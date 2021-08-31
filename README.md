# ListBoxTemplateMouseClickCommand
1.Выбрав корневой объект ЛКМ, а затем выбираем его дочерний объект ЛКМ, кликаем по выбраному дочернему объекту 2 раза ЛКМ, чтобы взять объект на редактирование, открывается диалоговое окно редактирование, в диалоговой окне нажимаем ESC или отмена - наблюдаем как сразу же выполняется команда открытия диалогового окна редактирования для корневого элемента, что является не жалательным поведением. 
![Variant 1](https://user-images.githubusercontent.com/51095170/131520179-1d0f6a7a-f4cf-471c-90e2-c77e39c5fe7b.gif)

2.Выбрав корневой объект ЛКМ, а затем выбрав НЕ его дочерний(дочерний объект из другого корневого элемента) объект ЛКМ, кликаем по выбраному дочернему объекту 2 раза ЛКМ, чтобы взять объект на редактирование, открывается диалоговое окно редактирование, в диалоговой окне нажимаем ESC или отмена - наблюдаем как сразу же выполняется команда открытия диалогового окна редактирования для предыдущего выбранного элемента - корневого элемента
![Variant 2](https://user-images.githubusercontent.com/51095170/131520184-9830baec-3a3e-4b65-bd29-19162ab13d70.gif)
Вывод: при использовании ListBox совместно с i:Interaction.Triggers InvokeCommandAction - команда выполняется всех выбранных элементов ListBox

Ожидаемое поведение - выполнять команду взятие на редактирование только для последнего выбранного элемента - как через нажатие клавиши Enter(Return)
