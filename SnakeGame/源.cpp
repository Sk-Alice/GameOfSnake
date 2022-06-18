#include <iostream>
#include <graphics.h>       // ͼ�ο���
#include <conio.h>          // ��������, _getch()
#include <time.h>           // ������� srand()��rand()         
#include <windows.h>        // �����ߵ��ٶ� Sleep()

using namespace std;

// �������

// ��������
typedef struct Point
{
    int x;
    int y;
}MYPOINT;
// �ߵ�����
struct Snake
{
    MYPOINT xy[100];        // �洢�ߵĽ��������꣬��ʾ�ߵ������100
    int num;                // �ߵĳ���(����)
    char position;          // ����
}snake;
// ʳ������
struct Food
{
    MYPOINT xy;
    int flag;                // ���ʳ���Ƿ����
    int grade;               // ����
}food;

// ���ھ�� (�����Ĵ���)
HWND hwnd = NULL;
// �ѷ���ö�ٳ���
enum position { _up, _down, _left, _right };

// �������
void Init_snake();           // ��ʼ����
void Draw_snake();           // ����
void Move_snake();           // �ƶ���
void Key_down();             // ���������ߵ��ƶ�
void Init_food();            // ��ʼ��ʳ��
void Draw_food();            // ��ʳ��
void Eat_food();             // ��ʳ��
void Show_grade();           // ��ʾ����
int Snake_die();             // ��Ϸ����,����

int main()
{
    // ���ƴ���
    hwnd = initgraph(800, 600); // ���ڴ�С
    setbkcolor(WHITE);          // ���ڱ�����ɫ
    cleardevice();              // ˢ�´���
    Init_snake();               // ��ʼ����

    while (1)
    {
        cleardevice();          // ˢ�´���
        Draw_snake();           // ����
        Move_snake();           // �ƶ���

        Draw_food();            // ��ʳ��
        Eat_food();             // ��ʳ��
        Show_grade();           // ��ʾ����

        if (Snake_die())        // �������������ѭ��
        {
            break;
        }
        if (food.flag == 0)     // ���ʳ�ﲻ���ڣ�����ʳ��
        {
            Init_food();        // ��ʼ��ʳ��
        }
        if (_kbhit())           // �жϰ����Ƿ���
        {
            Key_down();         // ���������ߵ��ƶ�����
        }

        Sleep(100);             // �����ߵ��ٶ�
    }

    // ���հ����˳�
    int temp = _getch();        // ��ֹ�����󴰿�����
    closegraph();               // �رմ���

    return 0;
}

void Init_snake()           // ��ʼ���ߵ�ǰ����
{
    snake.xy[2].x = 0;
    snake.xy[2].y = 0;

    snake.xy[1].x = 10;
    snake.xy[1].y = 0;

    snake.xy[0].x = 20;
    snake.xy[0].y = 0;

    snake.num = 3;
    snake.position = _right;
}

void Draw_snake()            // ����
{
    for (int i = 0; i < snake.num; i++)
    {
        setlinecolor(BLACK);    // �߿���ɫ
        setfillcolor(GREEN);    // �ߵ���ɫ
        fillrectangle(snake.xy[i].x, snake.xy[i].y, snake.xy[i].x + 10, snake.xy[i].y + 10);     // �������δ�����
    }
}

void Move_snake()            // �ƶ���
{
    // �����ƶ�ԭ��-����
    for (int i = snake.num - 1; i > 0; i--)     //����β��ʼ,�ߵ�������ǰ�ƶ�
    {
        snake.xy[i].x = snake.xy[i - 1].x;
        snake.xy[i].y = snake.xy[i - 1].y;
    }
    // ��ͷ���ƶ�
    switch (snake.position)
    {
    case _up:
        snake.xy[0].y -= 10;
        break;
    case _down:
        snake.xy[0].y += 10;
        break;
    case _left:
        snake.xy[0].x -= 10;
        break;
    case _right:
        snake.xy[0].x += 10;
        break;
    default:
        break;
    }
}

void Key_down()              // ���������ߵ��ƶ�
{
    char key = _getch();
    if (key == 32)           // �ո�Ϊ32,��ͣ
    {
        MessageBox(hwnd, "��ͣ", "��ͣ", 0);
        while (_getch() != 32);
    }

    switch (key)
    {
        // ����ΪС����
    case 'w':
    case 'W':
    case 72:
        if (snake.position != _down) {
            snake.position = _up;
        }
        break;
    case 's':
    case 'S':
    case 80:
        if (snake.position != _up) {
            snake.position = _down;
        }
        break;
    case 'a':
    case 'A':
    case 75:
        if (snake.position != _right) {
            snake.position = _left;
        }
        break;
    case 'd':
    case 'D':
    case 77:
        if (snake.position != _left) {
            snake.position = _right;
        }
        break;
    }
}

void Init_food()             // ��ʼ��ʳ��
{
    srand((unsigned int)time(NULL));     // �����������
    food.xy.x = rand() % 80 * 10;        // ���� %80*10 ��ʾ���ڴ�С
    food.xy.y = rand() % 60 * 10;
    food.flag = 1;                       // ��ʾʳ�����

    for (int i = 0; i < snake.num; i++)
    {
        // �ж�ʳ���Ƿ����ߵ�����
        if (food.xy.x == snake.xy[i].x && food.xy.y == snake.xy[i].y)
        {
            // ����ߵ�������, ���²���
            food.xy.x = rand() % 80 * 10;
            food.xy.y = rand() % 60 * 10;
        }
    }
}

void Draw_food()             // ��ʳ��
{
    setlinecolor(BLACK);     // �߿���ɫ
    setfillcolor(RED);       // ʳ��Ϊ��ɫ
    fillrectangle(food.xy.x, food.xy.y, food.xy.x + 10, food.xy.y + 10);    // �����δ���ʳ��
}

void Eat_food()              // ��ʳ��
{
    // ����ͷ��ʳ����ײ
    if (snake.xy[0].x == food.xy.x && snake.xy[0].y == food.xy.y)
    {
        food.flag = 0;
        snake.num++;
        food.grade += 10;
    }
}

void Show_grade()            // ��ʾ����
{
    char grade[100] = "";
    sprintf_s(grade, "������%d", food.grade);   // ������д���ַ�����
    setbkmode(TRANSPARENT);                    // ����͸����ɫ����
    settextcolor(LIGHTBLUE);                   // ����Ϊǳ��ɫ
    outtextxy(650, 30, grade);                 // ����Ӧλ����ʾ
}

int Snake_die()              // ��Ϸ����,����
{
    // ײǽ
    if (snake.xy[0].x < 0 || snake.xy[0].x > 800 || snake.xy[0].y < 0 || snake.xy[0].y > 600)
    {
        MessageBox(hwnd, "ײǽ����Ϸ������", "ײǽ����", 0); // ��������
        return 1;
    }
    // �Լ�ײ�Լ�
    for (int i = 1; i < snake.num; i++)
    {
        if (snake.xy[0].x == snake.xy[i].x && snake.xy[0].y == snake.xy[i].y)
        {
            MessageBox(hwnd, "��ɱ����Ϸ������", "��ɱ����", 0);
            return 1;
        }
    }
    return 0;
}